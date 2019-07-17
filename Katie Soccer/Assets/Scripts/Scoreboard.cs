using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
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

    public void HideMessage()
    {
        MessageAnimator.ResetTrigger("SlideIn");
        MessageAnimator.SetTrigger("SlideOut");
    }
}
