using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame: MonoBehaviour
{
    public SpriteRenderer color;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            color.color = Color.grey;
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentScene"));
        }
    }
}
