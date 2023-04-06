using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CondimentView : MonoBehaviour
{
    
    // this should get a parent class at some point?

    [SerializeField] private SpriteRenderer inOrderDisplay;
    
    // for when you do it right
    public void SqueezeBottle()
    {
        DOTween.Sequence()
            .Append(gameObject.transform.DOScaleX(0.7f, MusicManager.Instance.BeatDuration / 3))
            .Append(gameObject.transform.DOScaleX(1f, MusicManager.Instance.BeatDuration / 3));
    }

    // for when you do it wrong
    public void ShakeBottle()
    {
        DOTween.Sequence()
            .Append(gameObject.transform.DOPunchPosition(
                new Vector3(0.5f, 0.5f, 0f), MusicManager.Instance.BeatDuration / 3));
    }
    
    // for displaying if its part of the order
    public void ChangeColor(Color color)
    {
        DOTween.Sequence()
            .Append(inOrderDisplay.DOColor(color, MusicManager.Instance.BeatDuration / 2));
    }
}
