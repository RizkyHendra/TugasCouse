using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float timeDestroy;
    private float initTime;

    private GameObject CM;
    private void Start()
    {
        initTime = 0;
        CM = GameObject.Find("CoinManager");
    }
    // Update is called once per frame
    void Update()
    {
        if (initTime <= timeDestroy)
        {
            initTime += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
            CM.GetComponent<CoinManager>().coinCount -= 1;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Destroy(this.gameObject);
            CM.GetComponent<CoinManager>().coinCount -= 1;
        }
        if(other.tag == "Coin")
        {
            Destroy(other.gameObject);
            CM.GetComponent<CoinManager>().spawnCoin();
        }
    }
}
