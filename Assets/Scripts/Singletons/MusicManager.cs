using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    // singleton insurance, private set
    //public static MusicManager Instance { get; private set; }

    // wwise related info
    [SerializeField] private AK.Wwise.Bank soundBank;
    [SerializeField] private AK.Wwise.Event musicEvent;

    // result of wwise event posting
    private uint _playingID;

    // normalization factor
    public int NormalizationFactor = 1000;
    
    // beat/bar duration info for reference
    public float BeatDuration { get; private set; }
    public float BarDuration { get; private set; }
    public int CurrentPlaybackTime { get; private set; }
    // normalized
    public int NormalizedBeatDuration { get; private set; }
    public int NormalizedBarDuration { get; private set; }
    public int NormalizedCurrentPlaybackTime { get; private set; }

    // events for subscription, observer pattern
    public event EventHandler OnCue;
    public event EventHandler OnBeat;
    public event EventHandler OnBar;

    public override void Awake()
    {
        // run Singleton awake first
        base.Awake();
        // load wwise soundbank
        soundBank.Load();
    }

    private void Start()
    {
        // posting callback to wwise music event with desired flags
        _playingID = musicEvent.Post(
            gameObject,
            (uint)(AkCallbackType.AK_MusicSyncAll
                    | AkCallbackType.AK_EnableGetMusicPlayPosition
                    | AkCallbackType.AK_MIDIEvent),
            OnWwiseCallback);
    }

    private void OnWwiseCallback(object cookie, AkCallbackType type, object info)
    {
        // local variable for storage of musicInfo
        AkMusicSyncCallbackInfo musicInfo;
        
        // insure info type
        if (info is AkMusicSyncCallbackInfo)
        {
            // cast info to necessary type
            musicInfo = (AkMusicSyncCallbackInfo)info;
            // derive durations from cast musicInfo
            // making it times 1000 so that we can actually register that there is a difference lmao
            BeatDuration = musicInfo.segmentInfo_fBeatDuration;
            BarDuration = musicInfo.segmentInfo_fBarDuration;

            // normalized beat duration time for inputs and such
            NormalizedBeatDuration = (int)(BeatDuration * NormalizationFactor);
            NormalizedBarDuration = (int)(BarDuration * NormalizationFactor);

            // invoke correct event based on type passed from wwise to callback
            switch (type)
            {
                case AkCallbackType.AK_MusicSyncUserCue:
                    OnCue?.Invoke(this, EventArgs.Empty);
                    break;
                case AkCallbackType.AK_MusicSyncBeat:
                    OnBeat?.Invoke(this, EventArgs.Empty);
                    break;
                case AkCallbackType.AK_MusicSyncBar:
                    OnBar?.Invoke(this, EventArgs.Empty);
                    break;
                
            }
        }
    }

    private void Update()
    {
        CurrentPlaybackTime = GetMusicTimeInMS();
        NormalizedCurrentPlaybackTime = CurrentPlaybackTime * NormalizationFactor;
    }
    
    public int GetMusicTimeInMS() {
        AkSegmentInfo segmentInfo = new AkSegmentInfo();
        AkSoundEngine.GetPlayingSegmentInfo(_playingID, segmentInfo, true);
        return segmentInfo.iCurrentPosition;
    }
}
