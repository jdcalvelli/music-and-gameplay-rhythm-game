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

    // beat/bar duration info for reference
    public float beatDuration { get; private set; }
    public float barDuration { get; private set; }

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
            beatDuration = musicInfo.segmentInfo_fBeatDuration;
            barDuration = musicInfo.segmentInfo_fBarDuration;

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
}
