using UnityEngine;

public class Interactable : MonoBehaviour
{

    public virtual void Interact()
    {
        Debug.Log("Etkileþim gerçekleþti: " + gameObject.name);

    }
}