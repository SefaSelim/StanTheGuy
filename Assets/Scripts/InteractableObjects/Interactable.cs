using UnityEngine;

public class Interactable : MonoBehaviour
{

    public virtual void Interact()
    {
        Debug.Log("Etkile�im ger�ekle�ti: " + gameObject.name);

    }
}