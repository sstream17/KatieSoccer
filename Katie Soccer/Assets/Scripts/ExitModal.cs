using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExitModal : MonoBehaviour
{
    public TextMeshProUGUI Message;
    public Button ExitButton;

    public void SetMessage(string exit)
    {
        Message.text = $"You are about to lose progress. Are you sure you want to {exit.ToLower()}?";
        TextMeshProUGUI buttonText = ExitButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = exit;
    }

    public void SetExitButton(UnityAction action)
    {
        ExitButton.onClick.RemoveAllListeners();
        ExitButton.onClick.AddListener(action);
    }
}
