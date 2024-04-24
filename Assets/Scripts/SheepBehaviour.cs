using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehaviour : MonoBehaviour
{
    public float sheepSpeed = 10;

    void Update()
    {
        Movement();      
    }

    void Movement () 
    {
        transform.position = transform.position + (Vector3.back * sheepSpeed/100);
    }
}
