using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 3f;

    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (move.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (move.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        transform.Translate(move * Time.deltaTime * Speed);

    }
}
