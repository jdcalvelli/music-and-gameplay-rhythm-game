using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CondimentView : MonoBehaviour
{
    
    // this should get a parent class at some point

    public void SqueezeBottle()
    {
        DOTween.Sequence()
            .Append(gameObject.transform.DOScaleX(0.7f, MusicManager.Instance.BeatDuration / 2))
            .Append(gameObject.transform.DOScaleX(1f, MusicManager.Instance.BeatDuration / 2));
    }
}
