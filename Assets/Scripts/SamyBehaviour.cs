using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamyBehaviour : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public int currentDirection = 0;
    public Vector3[] directions = {new Vector3(-1,0,1), new Vector3(1,0,1),
                                   new Vector3(1,0,-1), new Vector3(-1,0,-1)};

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10;
        currentDirection = 0;
    }

    void Update()
    {
        rb.velocity = directions[currentDirection]*speed;
    }

    private void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag != "Floor")
        {
            currentDirection += 1; 
            switch(currentDirection)
            {
                case 0: transform.localRotation = Quaternion.Euler(0f,-90f,0f); break;
                case 1: transform.localRotation = Quaternion.Euler(0f,0f,0f); break;
                case 2: transform.localRotation = Quaternion.Euler(0f,90f,0f); break;
                case 3: transform.localRotation = Quaternion.Euler(0f,180f,0f); break;
                default: currentDirection = 0; break;
            }
        }   
    }
}
