using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkiraBehaviour : MonoBehaviour
{
    public GameObject target;
    public Animator animator;
    public float speed = 5;
    public bool isSleeping = false;

    void Start()
    {
        StartCoroutine("Attack");    
    }

    IEnumerator Attack()
    {
        if(GameObject.FindGameObjectsWithTag("Sheep").Length > 0) 
        {
            target = GameObject.FindGameObjectsWithTag("Sheep")[0];
            animator.Play("AkiraJump");
            transform.GetComponent<Rigidbody>().detectCollisions = true;
            transform.GetComponent<Rigidbody>().isKinematic = false;
        }
        yield return new WaitForSeconds(25);
        StartCoroutine("Attack");
    }    

    private void FixedUpdate() 
    {
        if(target)
        {
            isSleeping = false;
            transform.position = Vector3.MoveTowards(transform.position, 
            target.transform.position, speed);
            transform.LookAt(target.transform);
        }
        else if (!isSleeping)
        {
            animator.Play("AkiraSleep");
            isSleeping = true;
            transform.localRotation = Quaternion.Euler(0f,0f,0f); 
            transform.GetComponent<Rigidbody>().detectCollisions = false;
            transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
