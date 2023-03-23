using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestView : MonoBehaviour
{
    // punch on beat
    public void PunchOnBeat()
    {
        gameObject.transform.DOPunchScale(
            new Vector3(0.2f, 0.2f, 0f),
            MusicManager.Instance.beatDuration)
            .SetEase(Ease.InOutSine);
    }

    // rotate on bar
    public void RotateOnBar()
    {
        gameObject.transform.DORotate(
            new Vector3(0f, 0f, 90f), 
            MusicManager.Instance.beatDuration, 
            RotateMode.WorldAxisAdd)
            .SetEase(Ease.InOutCubic);
    }
    
    // color change on cue
    public void ColorChangeOnCue()
    {
        gameObject.GetComponent<SpriteRenderer>().DOColor(
            new Color(0.3f, 0.4f, 0.8f), 
            MusicManager.Instance.beatDuration);
    }
}
