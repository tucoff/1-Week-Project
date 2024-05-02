using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LorenBehaviour : MonoBehaviour
{
    public bool canShoot = false;
    public GameObject killBall;

    private void Start() 
    { 
        canShoot = true; 
    }

    void Update()
    {
        if(GameObject.FindWithTag("Player").GetComponent<SC_Hold>().isHolding()
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand == this.gameObject)
        {  
            canShoot = true;
        }
        else
        {
            if (canShoot)
            {
                GameObject newBall = Instantiate(killBall, transform.GetChild(1));
                newBall.transform.parent = this.transform.parent;
                StartCoroutine("Shoot"); 
                canShoot = false;
            }
        }

    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(5);
        canShoot = true;
    }
}
