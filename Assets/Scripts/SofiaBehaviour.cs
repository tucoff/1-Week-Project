using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofiaBehaviour : MonoBehaviour
{
    public bool slowOn = true;
    public bool canShoot = false;
    public GameObject slowBall;

    private void Start() 
    {
        slowOn = true;   
        canShoot = true; 
    }

    void Update()
    {
        if(GameObject.FindWithTag("Player").GetComponent<SC_Hold>().isHolding()
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand == this.gameObject)
        {  
            if(slowOn)
            {
                StartCoroutine("SlowAll"); 
                slowOn = false;
            }
        }
        else
        {
            StopCoroutine("SlowAll");
            slowOn = true;

            if (canShoot)
            {
                GameObject newBall = Instantiate(slowBall, transform.GetChild(1));
                newBall.transform.parent = this.transform.parent;
                StartCoroutine("Shoot"); 
                canShoot = false;
            }
        }

    }

    IEnumerator SlowAll()
    {
        yield return new WaitForSeconds(5);

        foreach(GameObject sheep in GameObject.FindGameObjectsWithTag("Sheep"))
        {
            sheep.GetComponent<SheepBehaviour>().StartCoroutine("slowSheep");
        }
        
        slowOn = true;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(3);
        canShoot = true;
    }
}
