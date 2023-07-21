using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public float timeDestroy;
    private float initTime;

    private GameObject TM;
    private void Start()
    {
        initTime = 0;
        TM = GameObject.Find("TrapManager");
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
            TM.GetComponent<TrapManager>().trapCount -= 1;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Destroy(this.gameObject);
            TM.GetComponent<TrapManager>().trapCount -= 1;
        }
        if (other.tag == "Trap")
        {
            Destroy(other.gameObject);
            TM.GetComponent<TrapManager>().spawnTrap();
        }
    }
}

