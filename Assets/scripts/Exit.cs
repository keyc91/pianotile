using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public string objectId;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && objectId == "exit")
        {
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_ANDROID || UNITY_IOS
                    Application.Quit();
        #endif
        }
    }
}
