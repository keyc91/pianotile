using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.Audio;
using Melanchall.DryWetMidi.Common;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public float width = 10f;
    public float height = 5f;
    private System.Random random = new System.Random();
    public static int noteCount;
    private double lastRound;
    public int lastIndex = 0;

    public GameObject tile;

    void Start()
    {
        noteCount = 0;
        lastRound = 0;
        tile.tag = "white";
        Instance = this;
        SongManager songManager = GameObject.FindObjectOfType<SongManager>();
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }


    void Update()
    {
        double currentTime = Time.timeSinceLevelLoad;
        double noteSpawn = SongManager.Instance.timeStamps[noteCount];

        if ((currentTime >= noteSpawn && noteSpawn > lastRound) || currentTime == 0 && noteCount < 1)
        {
            spawner();
            if (noteCount < SongManager.Instance.timeStamps.Count - 1)
            {
                noteCount++;
            }
        }

        lastRound = currentTime;
    }


    void spawner()
    {
        int index = GenerateRandomNumber();

        while (index == lastIndex)
        {
            index = GenerateRandomNumber();
        }

        if (index >= 0 && index < transform.childCount)
        {
            Transform child = transform.GetChild(index);
            GameObject piano = Instantiate(tile, child.position, Quaternion.identity);
            ////////////////////
            piano.transform.parent = child;
        }
        lastIndex = index;
    }

    int GenerateRandomNumber()
    {
        int randomNumber = random.Next(0, 4);
        return randomNumber;
    }
}







/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)

        {

            yield return null;

        }

        rawImage.texture = videoPlayer.texture;
        PlayVideo();
    }
}*/
