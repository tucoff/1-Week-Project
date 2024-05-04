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
            GameObject.Find("Serena").transform.localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.Find("Serena").transform.localRotation = Quaternion.Euler(0f,0f,0f);
        }

        if(sheeps >= 10 && dogs == 2)
        {
            dogs = 3;
            GameObject.Find("Akira").transform.localPosition = new Vector3(-4, 8f, -5f);
            GameObject.Find("Akira").transform.GetComponent<AkiraBehaviour>().enabled = true;
        }

        if(sheeps >= 20 && dogs == 3)
        {
            dogs = 4;
            GameObject.Find("Sofia").transform.localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.Find("Sofia").transform.localRotation = Quaternion.Euler(0f,0f,0f);
            GameObject.Find("Sofia").transform.GetComponent<SofiaBehaviour>().enabled = true;
        }

        if(sheeps >= 40 && dogs == 4)
        {
            dogs = 5;
            GameObject.Find("Loren").transform.localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.Find("Loren").transform.localRotation = Quaternion.Euler(0f,0f,0f);
            GameObject.Find("Loren").transform.GetComponent<LorenBehaviour>().enabled = true;
        }

        if(sheeps >= 60 && dogs == 5)
        {
            dogs = 6;
            GameObject.Find("Preta").transform.localPosition = new Vector3(-4, 8f, -5f);
            GameObject.Find("Preta").transform.localRotation = Quaternion.Euler(0f,0f,0f);
            GameObject.Find("Preta").transform.GetComponent<PretaBehaviour>().enabled = true;
        }

        if(sheeps >= 80 && dogs == 6)
        {
            dogs = 7;
            GameObject.Find("Mel").transform.localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.Find("Mel").transform.localRotation = Quaternion.Euler(0f,0f,0f);
        }

        if(sheeps >= 100 && dogs == 7)
        {
            dogs = 8;
            GameObject.Find("Pequena").transform.localPosition = new Vector3(-4, 9.25f, -5f);
            GameObject.Find("Pequena").transform.localRotation = Quaternion.Euler(0f,0f,0f);
        }
    }
}
