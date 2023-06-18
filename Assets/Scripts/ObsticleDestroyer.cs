using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleDestroyer : MonoBehaviour

{
    private GameObject player;
    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= (player.transform.position.z - 15)){
            Destroy(gameObject);
        }
        if(playerScript.gameOver){
            Destroy(gameObject);
        }   
    }
    
}
