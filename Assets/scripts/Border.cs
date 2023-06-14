using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Border : MonoBehaviour
{
    public static Border Instance; 
    public int destroyed;
    private int notesInFile;
    private string currentLevel;

    void Start()
    {
        Instance = this;
        SongManager songManager = GameObject.FindObjectOfType<SongManager>();
        notesInFile = SongManager.Instance.timeStamps.Count;
        currentLevel = PlayerPrefs.GetString("currentLevel");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        destroyed++;
        Destroy(col.gameObject);
        
        if (destroyed == notesInFile)
        {
            int scorepoints = (int)Scoreboard.Instance.scorepoints;
            if (scorepoints == notesInFile)
            {
                if (3 > PlayerPrefs.GetInt(currentLevel))
                {
                    PlayerPrefs.SetInt(currentLevel, 3);
                }
                SceneManager.LoadScene(5);
                
            }
        }
    }
}
