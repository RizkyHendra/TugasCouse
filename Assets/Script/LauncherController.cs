using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxTimeHold;
    public float maxForce;

    private bool isHold;

    private Vector3 initPos;

    private void Start()
    {
        isHold = false;
        initPos = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
            if (timeHold<=maxTimeHold)
            {
                transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - timeHold / 300);
            }
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        transform.position = initPos;
    }
}
