using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateBackwards : MonoBehaviour
{
    // Start is called before the first frame update
    public static float speedTrans = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speedTrans * Time.deltaTime);   
    }

    
}
