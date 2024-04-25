using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepmancyController : MonoBehaviour
{
    public float cd = 10;
    public bool canSpawn = false;
    public bool playAnimation = false;
    public GameObject sheep;
    public Transform[] spawnLocations;

    public int nextPos = 3;

    void Start()
    {
        StartCoroutine(WaitCD());
        StartCoroutine(SpawnAnimation());   
    }

    void FixedUpdate()
    {
        if (playAnimation)
        {
            //switch
            playAnimation = false;
        }

        if (canSpawn)
        {
            GameObject s = Instantiate(sheep);
            s.transform.position = spawnLocations[nextPos].position;
            nextPos = Random.Range(1,5);
            canSpawn = false;
            StartCoroutine(WaitCD());
        }
    }

    IEnumerator WaitCD()
    {
        yield return new WaitForSeconds(cd);
        canSpawn = true;
    }

    IEnumerator SpawnAnimation()
    {
        yield return new WaitForSeconds(cd - 1.5f);
        playAnimation = true;
    }
}
