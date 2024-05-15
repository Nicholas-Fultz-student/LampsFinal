
using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
    [SerializeField]string interactionText = " ";

    public UnityEvent OnInteract = new UnityEvent();


    public string GetInteractionText()
    {
        return interactionText;
    }

    public void Interact()
    {
        OnInteract.Invoke();
    }

    private void OnEnable()
    {

    }
}

