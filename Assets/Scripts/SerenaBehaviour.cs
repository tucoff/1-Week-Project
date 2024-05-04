using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerenaBehaviour : MonoBehaviour
{    
    public bool isCounting = false;

    private void Start() 
    {
        StartCoroutine("PassiveHealing");
    }

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
        yield return new WaitForSeconds(0.3f);
        if(GameObject.FindWithTag("Controller").GetComponent<Life>().life < 100)
        {
            GameObject.FindWithTag("Controller").GetComponent<Life>().life += 1;
        }
        isCounting = false;
    }

    IEnumerator PassiveHealing()
    {
        yield return new WaitForSeconds(5f);
        if(GameObject.FindWithTag("Controller").GetComponent<Life>().life < 100)
        {
            GameObject.FindWithTag("Controller").GetComponent<Life>().life += 2;
        }
        StartCoroutine("PassiveHealing");
    }
}
