using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRemover : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < player.transform.position.z - 30){
            Destroy(gameObject);
        }
    }
}
