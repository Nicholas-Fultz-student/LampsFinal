using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private Text interactableName;
    [SerializeField] private float textUpdateDelay = 0.1f; // Adjust as needed

    private InteractionObject targetInteraction;
    private string pendingInteractionText = "";

    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit;

        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            InteractionObject newTargetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>();

            if (newTargetInteraction && newTargetInteraction.enabled)
            {
                // Check if the distance to the interaction object is within range
                float distanceToTarget = Vector3.Distance(transform.position, newTargetInteraction.transform.position);
                if (distanceToTarget <= maxDistance)
                {
                    targetInteraction = newTargetInteraction;
                    pendingInteractionText = targetInteraction.GetInteractionText(); // Update pending text
                    Invoke("UpdateInteractableNameText", textUpdateDelay); // Delay the text update
                    return; // Exit early
                }
            }
        }

        // No valid interaction object found or out of range, set text to empty string immediately
        SetInteractableNameText("");
    }

    private void UpdateInteractableNameText()
    {
        SetInteractableNameText(pendingInteractionText);
    }

    private void SetInteractableNameText(string newText)
    {
        if (interactableName)
        {
            interactableName.text = newText;
        }
    }

    public void TryInteract()
    {
        if (targetInteraction && targetInteraction.enabled)
        {
            // Check if the distance to the interaction object is within range
            float distanceToTarget = Vector3.Distance(transform.position, targetInteraction.transform.position);
            if (distanceToTarget <= maxDistance)
            {
                targetInteraction.Interact();
            }
        }
    }
}
