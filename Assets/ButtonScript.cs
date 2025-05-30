using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject Window;

    bool isActive = false;

    public void OnMouseDown()
    {
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }

        Window.SetActive(isActive);
    }
}
