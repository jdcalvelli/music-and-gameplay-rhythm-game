using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FrownDirtyView : MonoBehaviour
{
    public void FadeFrown()
    {
        DOTween.Sequence()
            .Append(gameObject.GetComponent<SpriteRenderer>().DOFade(1f, MusicManager.Instance.BeatDuration / 2))
            //.AppendInterval(MusicManager.Instance.BeatDuration / 3)
            .Append(gameObject.GetComponent<SpriteRenderer>().DOFade(0f, MusicManager.Instance.BeatDuration / 2));
    }
}
