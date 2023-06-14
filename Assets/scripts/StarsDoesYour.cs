using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StarsDoesYour : MonoBehaviour
{
    public VideoPlayer video1;
    public VideoPlayer video2;
    public VideoPlayer video3;
    public VideoPlayer video4;

    private int doesYourNum;

    void Start()
    {
        PlayVideo(PlayerPrefs.GetInt("doesYour"));
    }

    void Update()
    {

    }

    public void PlayVideo(int index)
    {
        switch (index)
        {
            case 1:
                video1.Play();
                break;
            case 2:
                video2.Play();
                break;
            case 3:
                video3.Play();
                break;
            case 4:
                video4.Play();
                break;
            default:
                Debug.Log("Invalid video index: " + index);
                break;
        }
    }
}

