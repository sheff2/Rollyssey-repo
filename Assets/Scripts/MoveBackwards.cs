using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwards : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
       //rb.AddForce(Vector3.back * speed);
       if(transform.position.z < -8){
        Destroy(gameObject);
       }

       

    }
    private void FixedUpdate() {
        rb.AddRelativeForce (Vector3.back * 10);
    }
}
