using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public int jedaSpawn, maxTrap, trapCount;
    public float initTime;

    public GameObject trapPrefab, parentTrap, trapLocation;

    private void Start()
    {
        initTime = 0;
    }

    public void spawnTrap()
    {
        Instantiate(trapPrefab, trapLocation.transform.GetChild(Random.Range(0, trapLocation.transform.childCount - 1)).transform.position, transform.rotation, parentTrap.transform);
        initTime = 0;
    }

    private void Update()
    {
        if (trapCount < maxTrap)
        {
            initTime += Time.deltaTime;
            if (initTime >= jedaSpawn)
            {
                spawnTrap();
                trapCount += 1;
            }

        }
    }
}
