using UnityEngine;

public class Interactable : MonoBehaviour
{

    public virtual void Interact()
    {
        Debug.Log("Etkileşim gerçekleşti: " + gameObject.name);

    }
}