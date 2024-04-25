using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepKiller : MonoBehaviour
{
    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Sheep")
        {
            GameObject.Destroy(col.gameObject);
        }
    }
}
