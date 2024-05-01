using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerenaBehaviour : MonoBehaviour
{    
    bool isCounting = false;

    void Update()
    {
        if(GameObject.FindWithTag("Player").GetComponent<SC_Hold>().isHolding()
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand == this.gameObject)
        {   
            if (!isCounting)
            {
                StartCoroutine("LifeHeal");
                isCounting = true;
            } 
        }
        else
        {
            StopAllCoroutines();
        }
    }

    IEnumerator LifeHeal()
    {
        yield return new WaitForSeconds(2);
        if(GameObject.FindWithTag("Controller").GetComponent<Life>().life < 100)
        {
            GameObject.FindWithTag("Controller").GetComponent<Life>().life += 1;
        }
        isCounting = false;
    }
}
