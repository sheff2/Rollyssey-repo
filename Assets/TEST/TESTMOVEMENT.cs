using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTMOVEMENT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(0,0,.4f);
    }
}
