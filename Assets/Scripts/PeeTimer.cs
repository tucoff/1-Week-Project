using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeTimer : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 30f);
    }
}
