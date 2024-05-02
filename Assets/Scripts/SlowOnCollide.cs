using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowOnCollide : MonoBehaviour
{
    float ballSpeed = 5;

    private void Start() 
    {    
        Destroy(this.gameObject, 30f);
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
            col.gameObject.GetComponent<SheepBehaviour>().StartCoroutine("slowSheep");
        }

        if (col.gameObject.tag != "Floor")
        {
            Destroy(this.gameObject);
        }
    }
}
