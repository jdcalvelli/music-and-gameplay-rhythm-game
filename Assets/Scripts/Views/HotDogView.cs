using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HotDogView : MonoBehaviour
{
    public void MoveGlizzy(int beatValue)
    {
        switch (beatValue)
        {
            case 1:
                gameObject.transform.DOMoveX(-6, MusicManager.Instance.beatDuration);
                break;
            case 2:
                gameObject.transform.DOMoveX(-2, MusicManager.Instance.beatDuration);
                break;
            case 3:
                gameObject.transform.DOMoveX(2, MusicManager.Instance.beatDuration);
                break;
            case 4:
                gameObject.transform.DOMoveX(6, MusicManager.Instance.beatDuration);
                break;
        }
    }
}
