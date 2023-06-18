using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMover : MonoBehaviour
{
    public GameObject playr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
       //5 -5
        transform.position = new Vector3(0, 2 + (float)(Math.Round(playr.transform.position.y,2)),playr.transform.position.z - 3.8f);
    }
}
