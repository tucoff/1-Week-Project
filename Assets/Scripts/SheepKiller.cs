using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepKiller : MonoBehaviour
{
    public TMP_Text text;
    public float timeToKill = 0;

    private void Start() 
    {
        text = GameObject.FindWithTag("Canvas").transform.GetChild(1).GetComponent<TMP_Text>();    
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Sheep")
        {
            GameObject.FindWithTag("Controller").GetComponent<SheepCounter>().sheeps++;
            text.text = "Sheeps: " + GameObject.FindWithTag("Controller").GetComponent<SheepCounter>().sheeps;

            col.gameObject.GetComponent<SheepBehaviour>().enabled = false;
            col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            col.gameObject.GetComponent<Rigidbody>().useGravity = false;
            col.gameObject.GetComponent<Rigidbody>().mass = 0.01f;
            col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            col.gameObject.tag = "Dead";
            col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up);
            GameObject.Destroy(col.gameObject, timeToKill);
        }
    }
}