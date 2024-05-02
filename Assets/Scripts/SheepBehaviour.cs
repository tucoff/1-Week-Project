using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehaviour : MonoBehaviour
{
    public float sheepSpeed = 10;
    bool slowed = false;

    void Update()
    {
        Movement();      
    }

    void Movement () 
    {
        transform.position = transform.position + (Vector3.back * sheepSpeed/100);
    }

    public IEnumerator slowSheep()
    {
        if(!slowed){
            slowed = true;
            float lastSpeed = sheepSpeed;
            sheepSpeed = sheepSpeed*0.1f;
            yield return new WaitForSeconds(3);
            sheepSpeed = lastSpeed;
        }
        slowed = false;
    }
}
