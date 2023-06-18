using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSeekingTire : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - new Vector3(0,player.transform.position.y,0) - transform.position).normalized;

        rb.velocity = lookDirection * speed;
        
    }
}
