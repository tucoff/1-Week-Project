using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PretaBehaviour : MonoBehaviour
{
    public bool canPee = false;
    public GameObject pee;
    public bool walkCd = false;
    public float speed = 4f;
    Vector3 nextPos;
    public Animator animator;

    private void Start() 
    { 
        canPee = true; 
    }

    void FixedUpdate()
    {
        if (canPee)
        {
            GameObject newPee = Instantiate(pee, transform.GetChild(0));
            newPee.transform.parent = this.transform.parent;
            StartCoroutine("Pee"); 
            canPee = false;
        }

        if(!walkCd)
        {
            float x = transform.position.x + UnityEngine.Random.Range(-5,6);
            float z = transform.position.z + UnityEngine.Random.Range(-5,6);

            if(x>8f){x = 8f;}
            if(x<-17f){x = -17f;}
            if(z>160f){z = 160f;}
            if(z<-24f){z = -24f;}

            nextPos = new Vector3(x,0,z);
            StartCoroutine("WalkCooldown");
            walkCd = true;
        }

        if(transform.position != nextPos)
        {
            Move();
        }
    }

    void Move()
    {
        transform.LookAt(nextPos);
        animator.Play("PretaWalk");
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed);
    }

    IEnumerator Pee()
    {
        yield return new WaitForSeconds(15);
        canPee = true;
    }

    IEnumerator WalkCooldown()
    {
        animator.Play("PretaStand");
        yield return new WaitForSeconds(5);
        walkCd = false;
    }
}
