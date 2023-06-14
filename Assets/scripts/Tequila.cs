using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tequila : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("currentLevel", 6);
        PlayerPrefs.SetString("currentLevel", "tequila");
        SceneManager.LoadScene(6);
    }
}
