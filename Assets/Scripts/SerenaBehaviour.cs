using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerenaBehaviour : MonoBehaviour
{    
    public bool isCounting = false;

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
            isCounting = false;
        }
    }

    IEnumerator LifeHeal()
    {
        yield return new WaitForSeconds(1f);
        GameObject.FindWithTag("Controller").GetComponent<Life>().life += 2;
        isCounting = false;
    }
}
