using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI TeamOneScoreDisplay;
    public TextMeshProUGUI TeamTwoScoreDisplay;

    public void UpdateScoreboard(int teamOneScore, int teamTwoScore)
    {
        TeamOneScoreDisplay.text = teamOneScore.ToString();
        TeamTwoScoreDisplay.text = teamTwoScore.ToString();
    }
}
