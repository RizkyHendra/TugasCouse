using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int jedaSpawn, maxCoin, coinCount;
    public float initTime;

    public GameObject coinPrefab, parentCoin, coinLocation;

    private void Start()
    {
        initTime = 0;                
    }

    public void spawnCoin()
    {
            Instantiate(coinPrefab, coinLocation.transform.GetChild(Random.Range(0, coinLocation.transform.childCount - 1)).transform.position, transform.rotation, parentCoin.transform);
            initTime = 0;
    }

    private void Update()
    {
        if (coinCount < maxCoin)
        {
            initTime += Time.deltaTime;
            if (initTime >= jedaSpawn)
            {
                spawnCoin();
                coinCount += 1;
            }
            
        }
    }
}
