using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [SerializeField] private Text objectiveDisplay;

    [SerializeField] private string objectiveText = "I am an obj.";
    [SerializeField] private string completedText = "Objective Completed";

    public UnityEvent OnCompleteObjective = new UnityEvent();
    private void OnEnable()
    {
        objectiveDisplay.text = objectiveText;
    }

    public void CompletedObjective()
    {
        if(gameObject.activeSelf)
        {
        objectiveDisplay.text = " ";

        OnCompleteObjective.Invoke();

        gameObject.SetActive(false);
        }

    }
}
