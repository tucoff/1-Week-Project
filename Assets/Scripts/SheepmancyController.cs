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
    public Animator animator;
    private float sheepSpeed = 0;

    void Start()
    {
        sheepSpeed = sheep.GetComponent<SheepBehaviour>().sheepSpeed;
        StartCoroutine(SpawnAnimation());   
        StartCoroutine(WaitCD());
    }

    void FixedUpdate()
    {
        if (playAnimation)
        {
            switch(nextPos)
            {
                case 1: animator.Play("BossPos1", -1, 0f); break;
                case 2: animator.Play("BossPos2", -1, 0f); break;
                case 3: animator.Play("BossPos3", -1, 0f); break;
                case 4: animator.Play("BossPos4", -1, 0f); break;
                case 5: animator.Play("BossPos5", -1, 0f); break;
            }
            playAnimation = false;
        }

        if (canSpawn)
        {
            cd *= 0.95f; if(cd <= 2f){ cd = 2f; }
            GameObject s = Instantiate(sheep);
            s.GetComponent<SheepBehaviour>().sheepSpeed = sheepSpeed;
            s.transform.position = spawnLocations[nextPos-1].position;
            nextPos = Random.Range(1,6);
            sheepSpeed *= 1.1f;
            canSpawn = false;
            StartCoroutine(SpawnAnimation());  
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
