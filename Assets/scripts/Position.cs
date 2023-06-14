using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Position : MonoBehaviour
{
    public float width = 2f;
    public float height = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

