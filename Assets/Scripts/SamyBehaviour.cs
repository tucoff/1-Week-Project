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
        transform.localRotation = Quaternion.Euler(0f,45f,0f); 
    }

    void Update()
    {
        if((currentDirection <= 3 && !GameObject.FindWithTag("Player").GetComponent<SC_Hold>().isHolding()) 
           || (currentDirection <= 3 && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().isHolding()
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand != this.gameObject))
        { 
            rb.velocity = directions[currentDirection]*speed;
        } 
        
        transform.localPosition = 
            new Vector3(transform.localPosition.x,9.25f,transform.localPosition.z);

        if(GameObject.FindWithTag("Player").GetComponent<SC_Hold>().isHolding()
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand == this.gameObject)
        {    
           transform.localPosition = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag != "Floor")
        {
            if(col.gameObject.tag == "Cerca Direita" && currentDirection == 0) 
            {
                currentDirection++;
            }
            
            if(col.gameObject.tag == "Cerca Esquerda" && currentDirection == 2) 
            {
                currentDirection++;
            } 

            currentDirection++; 

            if (currentDirection > 3)
            {
                currentDirection = 0;
            }

            switch(currentDirection)
            {
                case 0: transform.localRotation = Quaternion.Euler(0f,45f,0f); break;
                case 1: transform.localRotation = Quaternion.Euler(0f,135f,0f); break;
                case 2: transform.localRotation = Quaternion.Euler(0f,225f,0f); break;
                case 3: transform.localRotation = Quaternion.Euler(0f,315f,0f); break;
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
}
