using System.Collections;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI TeamOneName;
    public TextMeshProUGUI TeamTwoName;
    public TextMeshProUGUI TeamOneScoreDisplay;
    public TextMeshProUGUI TeamTwoScoreDisplay;
    public Animator MessageAnimator;
    public TextMeshProUGUI MessageText;

    public void UpdateScoreboard(int teamOneScore, int teamTwoScore)
    {
        TeamOneScoreDisplay.text = teamOneScore.ToString();
        TeamTwoScoreDisplay.text = teamTwoScore.ToString();
    }

    public void DisplayMessage(string message)
    {
        MessageText.text = message;
        MessageAnimator.ResetTrigger("SlideOut");
        MessageAnimator.SetTrigger("SlideIn");
    }

    public bool HideMessage()
    {
        MessageAnimator.ResetTrigger("SlideIn");
        MessageAnimator.SetTrigger("SlideOut");
        return true;
    }

    public IEnumerator ShuffleMessage(string message)
    {
        HideMessage();
        yield return new WaitForSecondsRealtime(1f);
        DisplayMessage(message);
    }
}
