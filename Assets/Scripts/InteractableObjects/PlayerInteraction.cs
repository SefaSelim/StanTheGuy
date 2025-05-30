using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("UI")]
    public GameObject interactionPrompt;

    private Interactable currentInteractable;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interactable interactable = collision.GetComponent<Interactable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
            Debug.Log("Etkile�im alan�na girildi: " + interactable.gameObject.name);

            if (interactionPrompt != null)
                interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Interactable interactable = collision.GetComponent<Interactable>();
        if (interactable != null && interactable == currentInteractable)
        {
            Debug.Log("Etkile�im alan�ndan ��k�ld�: " + interactable.gameObject.name);
            currentInteractable = null;

            if (interactionPrompt != null)
                interactionPrompt.SetActive(false);
        }
    }
}