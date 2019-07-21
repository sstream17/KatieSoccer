using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSelection : MonoBehaviour
{
    public TextMeshProUGUI ScoreDisplay;
    public Button DecreaseButton;
    public Button IncreaseButton;
    public int NextMenu;
    public Menu Menu;

    private int scoreToWin;
    private readonly int minimumScore = 1;
    private readonly int maximumScore = 5;

    void OnEnable()
    {
        scoreToWin = int.Parse(ScoreDisplay.text);
    }

    public void UpdateScore(int score)
    {
        ScoreDisplay.text = score.ToString();
    }

    public void OnDecrease()
    {
        IncreaseButton.interactable = true;
        scoreToWin = scoreToWin - 1;
        UpdateScore(scoreToWin);

        if (scoreToWin == minimumScore)
        {
            DecreaseButton.interactable = false;
        }
    }

    public void OnIncrease()
    {
        DecreaseButton.interactable = true;
        scoreToWin = scoreToWin + 1;
        UpdateScore(scoreToWin);

        if (scoreToWin == maximumScore)
        {
            IncreaseButton.interactable = false;
        }
    }

    public void OpenNextMenu()
    {
        if (NextMenu == 2)
        {
            Menu.OpenTwoPlayerCustomizationMenu();
        }
    }
}