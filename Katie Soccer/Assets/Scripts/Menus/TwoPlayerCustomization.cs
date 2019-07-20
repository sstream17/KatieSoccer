using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TwoPlayerCustomization : MonoBehaviour
{
    public TMP_InputField TeamOneInput;
    public TMP_InputField TeamTwoInput;
    public Button NextButton;
    public Button BackButton;
    public Menu Menu;
    public LevelTransition LevelTransition;

    private enum Turn { TeamOne, TeamTwo };

    private void SetInputInteraction(bool teamOne, bool teamTwo)
    {
        TeamOneInput.interactable = teamOne;
        TeamTwoInput.interactable = teamTwo;
    }

    void Start()
    {
        SetInputInteraction(true, false);
        UpdateButtonFunctions(Turn.TeamOne);
        SetNextButtonText("Next");
    }

    public void SetNextButtonText(string text)
    {
        TextMeshProUGUI nextButtonText = NextButton.GetComponentInChildren<TextMeshProUGUI>();
        nextButtonText.text = text;
    }

    public void PlayerOneSet()
    {
        SetInputInteraction(false, true);
        UpdateButtonFunctions(Turn.TeamTwo);
        SetNextButtonText("Play");
    }

    public void PlayerOneReset()
    {
        SetInputInteraction(true, false);
        UpdateButtonFunctions(Turn.TeamOne);
        SetNextButtonText("Next");
    }

    public void PlayerTwoSet()
    {
        SetTeamNames(TeamOneInput.text, TeamTwoInput.text);
        LevelTransition.FadeToNextLevel();
    }

    public void SetTeamNames(string teamOneName, string teamTwoName)
    {
        GameData.TeamOneName = teamOneName;
        GameData.TeamTwoName = teamTwoName;
    }

    private void UpdateButtonFunctions(Turn turn)
    {
        NextButton.onClick.RemoveAllListeners();
        BackButton.onClick.RemoveAllListeners();
        if (turn.Equals(Turn.TeamOne))
        {
            NextButton.onClick.AddListener(PlayerOneSet);
            BackButton.onClick.AddListener(Menu.OpenPlayerSelectMenu);
        }
        else
        {
            NextButton.onClick.AddListener(PlayerTwoSet);
            BackButton.onClick.AddListener(PlayerOneReset);
        }
    }


}
