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
            isSleeping = false;

            if(GameObject.FindWithTag("Player").GetComponent<SC_Hold>().isHolding()
            && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand
            && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand == this.gameObject)
            {   
                GameObject.FindWithTag("Player").GetComponent<SC_Hold>().forceCancelHold();
                transform.GetComponent<SheepKiller>().enabled = true;
            }
        }
        yield return new WaitForSeconds(25);
        StartCoroutine("Attack");
    }    

    private void FixedUpdate() 
    {
        if(target)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
            target.transform.position, speed);
        }
        else if (!isSleeping)
        {
            animator.Play("AkiraSleep");
            isSleeping = true;
            transform.GetComponent<SheepKiller>().enabled = false;
        }
    }
}
