using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;


public class TileClick : MonoBehaviour
{
    public static TileClick Instance;
    public SpriteRenderer color;
    public int scorevalue = 1;
    public float speed = 5f;
    private double notesInFile;
    private string currentLevel;
    //public List<string> notesName = new List<string>();

    //public AudioClip[] noteAudioClips;
    private AudioSource audioSource;
    public GameObject tile;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SongManager songManager = GameObject.FindObjectOfType<SongManager>();
        notesInFile = (double)SongManager.Instance.timeStamps.Count;
        //notesName = SongManager.Instance.notesName;
        audioSource = GetComponent<AudioSource>();
        currentLevel = PlayerPrefs.GetString("currentLevel");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && color.color != Color.grey)
        {
            color.color = Color.grey;
            FindObjectOfType<Scoreboard>().Scoreup(scorevalue);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (color.color == Color.grey)
        {
            Debug.Log("slayed");
        }

        else if (col.collider.tag == "border")
        {
            double destroyed = (double)Scoreboard.Instance.scorepoints;
            double onePercent = 100 / notesInFile;
            double percent = (onePercent * destroyed);

            if (percent <= 60)
            {
                if (1 > PlayerPrefs.GetInt(currentLevel))
                {
                    PlayerPrefs.SetInt(currentLevel, 1);
                }

                SceneManager.LoadScene(3);
            }

            else if (percent < 100)
            {
                if (2 > PlayerPrefs.GetInt(currentLevel))
                {
                    PlayerPrefs.SetInt(currentLevel, 2);
                }

                SceneManager.LoadScene(4);
            }
        }
    }




    /*private void PlayNextNote()
    {

    }
   

    private void OnMouseButtonDown()
    {
       /* if (noteIndex >= 0 && noteIndex < noteAudioClips.Length)
        {
            audioSource.clip = noteAudioClips[noteIndex];
            audioSource.Play();
        }
        clicked++;
    }*/
}
