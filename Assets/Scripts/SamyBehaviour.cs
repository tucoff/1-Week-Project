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
        speed = 12;
        currentDirection = 0;
        StartCoroutine(SamyRNG());
    }

    void Update()
    {
        if(currentDirection <= 3)
        {
            rb.velocity = directions[currentDirection]*speed;
        }
    }

    private void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag != "Floor")
        {
            currentDirection++; 
            switch(currentDirection)
            {
                case 0: transform.localRotation = Quaternion.Euler(0f,-90f,0f); break;
                case 1: transform.localRotation = Quaternion.Euler(0f,0f,0f); break;
                case 2: transform.localRotation = Quaternion.Euler(0f,90f,0f); break;
                case 3: transform.localRotation = Quaternion.Euler(0f,180f,0f); break;
                default: currentDirection = 0; break;
            }
            if(speed > -30f && speed < 30f)
            {
                speed += Random.Range(-5f,6f);
            }
            else if (speed >= 30f)
            {
                speed -= Random.Range(10f,16f);
            }
            else if (speed <= -30f)
            {
                speed += Random.Range(10f,16f);
            }

            if(col.gameObject.tag == "Player")
            {
                speed = 12f;
            }
        }   
    }

    IEnumerator SamyRNG()
    {
        yield return new WaitForSeconds(Random.Range(1f,4f));
        currentDirection++;
        StartCoroutine(SamyRNG());        
    }
}
