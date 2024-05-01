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
            dogs++;
            GameObject.FindWithTag("Dogs").transform.GetChild(1).localPosition = new Vector3(-4, 9.25f, -5f);
        }

        if(sheeps >= 10 && dogs == 2)
        {
            dogs++;
            GameObject.FindWithTag("Dogs").transform.GetChild(0).localPosition = new Vector3(-4, 9.25f, -5f);
        }

        if(sheeps >= 20 && dogs == 3)
        {
            dogs++;
            GameObject.FindWithTag("Dogs").transform.GetChild(2).localPosition = new Vector3(-4, 9.25f, -5f);
        }

        if(sheeps >= 40 && dogs == 4)
        {
            dogs++;
            GameObject.FindWithTag("Dogs").transform.GetChild(3).localPosition = new Vector3(-4, 9.25f, -5f);
        }

        if(sheeps >= 60 && dogs == 5)
        {
            dogs++;
            GameObject.FindWithTag("Dogs").transform.GetChild(4).localPosition = new Vector3(-4, 9.25f, -5f);
        }

        if(sheeps >= 80 && dogs == 6)
        {
            dogs++;
            GameObject.FindWithTag("Dogs").transform.GetChild(5).localPosition = new Vector3(-4, 9.25f, -5f);
        }

        if(sheeps >= 100 && dogs == 7)
        {
            dogs++;
            GameObject.FindWithTag("Dogs").transform.GetChild(6).localPosition = new Vector3(-4, 9.25f, -5f);
        }
    }
}
