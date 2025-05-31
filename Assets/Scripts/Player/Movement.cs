using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 3f;

    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (move.x < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("IsWalking", true);
        }
        else if (move.x > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("IsWalking", true);

        }
        else
        {
            animator.SetBool("IsWalking", false);

        }

        transform.Translate(move * Time.deltaTime * Speed);

    }
}
