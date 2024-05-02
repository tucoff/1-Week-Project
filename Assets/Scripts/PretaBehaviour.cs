using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PretaBehaviour : MonoBehaviour
{
    public bool canPee = false;
    public GameObject pee;

    private void Start() 
    { 
        canPee = true; 
    }

    void Update()
    {
        if (canPee)
        {
            GameObject newPee = Instantiate(pee, transform.GetChild(0));
            newPee.transform.parent = this.transform.parent;
            StartCoroutine("Pee"); 
            canPee = false;
        }
    }

    IEnumerator Pee()
    {
        yield return new WaitForSeconds(15);
        canPee = true;
    }
}
