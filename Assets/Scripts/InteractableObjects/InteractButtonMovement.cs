using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonMovement : MonoBehaviour
{
    [SerializeField] Transform Targetpoint;


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Targetpoint.position + new Vector3(0,0.5f,0), Time.deltaTime * 5f);

    }
}
