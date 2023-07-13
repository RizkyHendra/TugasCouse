using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadleController : MonoBehaviour
{
    public KeyCode input;
    private float targetPressed, targetReleased;

    private HingeJoint hinge;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        targetPressed = hinge.limits.max;
        targetReleased = hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }
    void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;
        if (Input.GetKey(input))
        {

            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetReleased;
        }

        hinge.spring = jointSpring;


    }
}
