using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HotDogView : MonoBehaviour
{

    [SerializeField] private List<SpriteRenderer> condimentBlobs;

    // function to update view based on what condiment is added
    // quick and dirty
    public void ShowGlizzyCondiment(string condimentName)
    {
        switch (condimentName)
        {
            case "Ketchup":
                // show red square
                condimentBlobs[0].DOFade(1, MusicManager.Instance.BeatDuration / 3);
                break;
            case "Mustard":
                // show yellow square
                condimentBlobs[1].DOFade(1, MusicManager.Instance.BeatDuration / 3);
                break;
            case "Relish":
                // show green square
                condimentBlobs[2].DOFade(1, MusicManager.Instance.BeatDuration / 3);
                break;
            case "Beans":
                // show brown square
                condimentBlobs[3].DOFade(1, MusicManager.Instance.BeatDuration / 3);
                break;
        }
    }

    public void MoveGlizzy(int beatValue)
    {
        switch (beatValue)
        {
            case 1:
                gameObject.transform.DOMoveX(-6, MusicManager.Instance.BeatDuration / 3);
                break;
            case 2:
                gameObject.transform.DOMoveX(-2, MusicManager.Instance.BeatDuration / 3);
                break;
            case 3:
                gameObject.transform.DOMoveX(2, MusicManager.Instance.BeatDuration / 3);
                break;
            case 4:
                gameObject.transform.DOMoveX(6, MusicManager.Instance.BeatDuration / 3);
                break;
        }
    }
}
