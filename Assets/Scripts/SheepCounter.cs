using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCounter : MonoBehaviour
{
    public int sheeps = 0;
    public int dogs = 1;

    private void FixedUpdate() {
        if(sheeps >= 5 && dogs == 1)
        {
            dogs = 2;
            GameObject.FindWithTag("Dogs").transform.GetChild(1).localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.FindWithTag("Dogs").transform.GetChild(1).localRotation = Quaternion.Euler(0f,0f,0f);
        }

        if(sheeps >= 10 && dogs == 2)
        {
            dogs = 3;
            GameObject.FindWithTag("Dogs").transform.GetChild(0).localPosition = new Vector3(-4, 8f, -5f);
            GameObject.FindWithTag("Dogs").transform.GetChild(0).GetComponent<AkiraBehaviour>().enabled = true;
        }

        if(sheeps >= 20 && dogs == 3)
        {
            dogs = 4;
            GameObject.FindWithTag("Dogs").transform.GetChild(2).localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.FindWithTag("Dogs").transform.GetChild(2).localRotation = Quaternion.Euler(0f,0f,0f);
            GameObject.FindWithTag("Dogs").transform.GetChild(2).GetComponent<SofiaBehaviour>().enabled = true;
        }

        if(sheeps >= 40 && dogs == 4)
        {
            dogs = 5;
            GameObject.FindWithTag("Dogs").transform.GetChild(3).localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.FindWithTag("Dogs").transform.GetChild(3).localRotation = Quaternion.Euler(0f,0f,0f);
            GameObject.FindWithTag("Dogs").transform.GetChild(3).GetComponent<LorenBehaviour>().enabled = true;
        }

        if(sheeps >= 60 && dogs == 5)
        {
            dogs = 6;
            GameObject.FindWithTag("Dogs").transform.GetChild(4).localPosition = new Vector3(-4, 8f, -5f);
            GameObject.FindWithTag("Dogs").transform.GetChild(4).localRotation = Quaternion.Euler(0f,0f,0f);
            GameObject.FindWithTag("Dogs").transform.GetChild(4).GetComponent<PretaBehaviour>().enabled = true;
        }

        if(sheeps >= 80 && dogs == 6)
        {
            dogs = 7;
            GameObject.FindWithTag("Dogs").transform.GetChild(5).localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.FindWithTag("Dogs").transform.GetChild(5).localRotation = Quaternion.Euler(0f,0f,0f);
        }

        if(sheeps >= 100 && dogs == 7)
        {
            dogs = 8;
            GameObject.FindWithTag("Dogs").transform.GetChild(6).localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.FindWithTag("Dogs").transform.GetChild(6).localRotation = Quaternion.Euler(0f,0f,0f);
        }
    }
}
