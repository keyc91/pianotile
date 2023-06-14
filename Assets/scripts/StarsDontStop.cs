using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StarsDontStop : MonoBehaviour
{
    public VideoPlayer video1;
    public VideoPlayer video2;
    public VideoPlayer video3;
    public VideoPlayer video4;

    public int dontStopNum;

    void Start()
    {
        PlayVideo(PlayerPrefs.GetInt("dontStop"));
        Debug.Log("dont stop " + PlayerPrefs.GetInt("dontStop"));
    }

    public void PlayVideo(int index)
    {
        switch (index)
        {
            case 0:
                video1.Play();
                break;
            case 1:
                video2.Play();
                break;
            case 2:
                video3.Play();
                break;
            case 3:
                video4.Play();
                break;
            default:
                Debug.Log("Invalid video index: " + index);
                break;
        }
    }
}


