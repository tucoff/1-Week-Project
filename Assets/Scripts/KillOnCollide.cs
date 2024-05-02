using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnCollide : MonoBehaviour
{
    float ballSpeed = 10;

    private void Start() 
    {    
        Destroy(this.gameObject, 15f);
    }

    void Update()
    {
        Movement();      
    }

    void Movement () 
    {
        transform.position = transform.position + (Vector3.forward * ballSpeed/100);
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Sheep")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag != "Floor" && col.gameObject.tag != "Pee")
        {
            Destroy(this.gameObject);
        }
    }
}
