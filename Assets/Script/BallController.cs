using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxSpeed;

    private Rigidbody rig;
    
    private Vector3 initPos;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        initPos = transform.position;
    }

    private void Update()
    {
        if (rig.velocity.magnitude > maxSpeed)
        {
            rig.velocity = rig.velocity.normalized * maxSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Game Over")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.position = initPos;
        }


    }
}
