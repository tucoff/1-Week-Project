using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelBehaviour : MonoBehaviour
{
    bool isHolding = true;

    void Update()
    {
        if(GameObject.FindWithTag("Player").GetComponent<SC_Hold>().isHolding()
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand
           && GameObject.FindWithTag("Player").GetComponent<SC_Hold>().dogInHand == this.gameObject)
        {   
            if (isHolding)
            {
                StartCoroutine("ThrowMe");
                isHolding = false;
            } 
        }
    }

    IEnumerator ThrowMe()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindWithTag("Player").GetComponent<SC_Hold>().forceCancelHold();
        GameObject.FindWithTag("Controller").GetComponent<Life>().life--;
        isHolding = true;
    }
}
