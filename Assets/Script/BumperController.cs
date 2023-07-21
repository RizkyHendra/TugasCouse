using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color1, color2, color3;

    private Renderer rendererMat;
    private Animator animator;

    int colorNumber = 1;
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
        if (colorNumber == 1)
        {
            rendererMat.material.color = color1;
            colorNumber = 2;
        }
        else if (colorNumber == 2)
        {
            rendererMat.material.color = color2;
            colorNumber = 3;
        }
        else if (colorNumber == 3)
        {
            rendererMat.material.color = color3;
            colorNumber = 1;
        }
    }
}
