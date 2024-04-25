using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int life = 100;

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "Sheep")
        {
            life -= 10;
            GameObject.Destroy(col.gameObject);
        }
    }
}
