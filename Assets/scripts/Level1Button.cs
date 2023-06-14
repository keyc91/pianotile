using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Button : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }
}
