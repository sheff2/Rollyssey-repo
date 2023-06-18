using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    
    public GameObject road;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= 0){
            //Destroy(gameObject);
            //Instantiate(road, new Vector3(0,0,72.69f), road.transform.rotation);
            transform.position = new Vector3(0,0,72.69f);
        }
    }
    

}
