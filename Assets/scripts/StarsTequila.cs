using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StarsTequila : MonoBehaviour
{
    public VideoPlayer video1;
    public VideoPlayer video2;
    public VideoPlayer video3;
    public VideoPlayer video4;
    private int tequila;

    void Start()
    {
        tequila = PlayerPrefs.GetInt("tequila");
        Debug.Log("tequila " + tequila);
        PlayVideo(tequila);
    }


    public void PlayVideo(int index)
    {
        switch (index)
        {
            case 0:
                PrepareAndPlay(video1);
                break;
            case 1:
                PrepareAndPlay(video2);
                break;
            case 2:
                PrepareAndPlay(video3);
                break;
            case 3:
                PrepareAndPlay(video4);
                break;
            default:
                Debug.Log("Invalid video index: " + index);
                break;
        }
    }

    public void PrepareAndPlay(VideoPlayer videoPlayer) 
    { 
        videoPlayer.Prepare(); 
        videoPlayer.Play(); 
    }
}
