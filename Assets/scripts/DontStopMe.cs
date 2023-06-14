using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontStopMe : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("currentLevel", 0);
        PlayerPrefs.SetString("currentLevel", "dontStop");
        SceneManager.LoadScene(0);
    }
}
