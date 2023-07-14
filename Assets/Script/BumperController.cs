using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;

    private Renderer rendererMat;
    private Animator animator;
    private void Start()
    {
        rendererMat = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        setColor();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            rendererMat.material.color = Color.red;
            animator.SetTrigger("hit");
            Invoke("setColor",0.2f);
        }

    }
    private void setColor()
    {
        rendererMat.material.color = color;
    }
}
