using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TwoPlayerCustomization : MonoBehaviour
{
    public TMP_InputField TeamOneInput;
    public TMP_InputField TeamTwoInput;
    public Button NextButton;
    public Button BackButton;
    public ColorButton[] ColorButtons;
    public Menu Menu;
    public LevelTransition LevelTransition;

    private Color teamOneColor = PieceColors.Red;
    private Color teamTwoColor = PieceColors.Blue;

    private enum Turn { TeamOne, TeamTwo };

    private void SetInputInteraction(bool teamOne, bool teamTwo)
    {
        TeamOneInput.interactable = teamOne;
        TeamTwoInput.interactable = teamTwo;
    }

    private void SetFirstColorSelected()
    {
        for (int i = 0; i < ColorButtons.Length; i++)
        {
            if (!ColorButtons[i].IsSelected)
            {
                ColorButtons[i].OnSelected();
                break;
            }
        }
    }

    private void OnEnable()
    {
        SetFirstColorSelected();
    }

    void Start()
    {
        SetInputInteraction(true, false);
        UpdateButtonFunctions(Turn.TeamOne);
        SetNextButtonText("Next");
    }

    public void DeselectOtherColors()
    {
        foreach (ColorButton colorButton in ColorButtons)
        {
            if (colorButton.Button.interactable)
            {
                colorButton.OnDeselected();
            }
        }
    }

    public void SetNextButtonText(string text)
    {
        TextMeshProUGUI nextButtonText = NextButton.GetComponentInChildren<TextMeshProUGUI>();
        nextButtonText.text = text;
    }

    public void SetButtonNotInteractable()
    {
        foreach (ColorButton colorButton in ColorButtons)
        {
            if (colorButton.IsSelected)
            {
                colorButton.Button.interactable = false;
                break;
            }
        }
    }

    public void SetButtonsInteractable()
    {
        foreach (ColorButton colorButton in ColorButtons)
        {
            colorButton.Button.interactable = true;
        }
    }

    public Color SetTeamColor(Color color)
    {
        ColorButton colorButton = null;
        foreach (ColorButton button in ColorButtons)
        {
            if (button.Button.interactable && button.IsSelected)
            {
                colorButton = button;
                break;
            }
        }

        if (colorButton != null)
        {
            switch (colorButton.name)
            {
                case "RedButton":
                    return PieceColors.Red;
                case "BlueButton":
                    return PieceColors.Blue;
                case "PinkButton":
                    return PieceColors.Pink;
                case "PurpleButton":
                    return PieceColors.Purple;
                case "YellowButton":
                    return PieceColors.Yellow;
                case "GreenButton":
                    return PieceColors.Green;
                case "OrangeButton":
                    return PieceColors.Orange;
                case "BlackButton":
                    return PieceColors.Black;
            }
        }
        return color;
    }

    public void PlayerOneSet()
    {
        teamOneColor = SetTeamColor(teamOneColor);
        SetInputInteraction(false, true);
        SetButtonNotInteractable();
        UpdateButtonFunctions(Turn.TeamTwo);
        SetFirstColorSelected();
        SetNextButtonText("Play");
    }

    public void PlayerOneReset()
    {
        SetInputInteraction(true, false);
        SetButtonsInteractable();
        SetFirstColorSelected();
        UpdateButtonFunctions(Turn.TeamOne);
        SetNextButtonText("Next");
    }

    public void PlayerTwoSet()
    {
        teamTwoColor = SetTeamColor(teamTwoColor);
        GameData.SetTeamNames(TeamOneInput.text, TeamTwoInput.text);
        GameData.SetTeamColors(teamOneColor, teamTwoColor);
        LevelTransition.FadeToNextLevel();
    }

    IEnumerator ResetBeforeExiting()
    {
        DeselectOtherColors();
        yield return new WaitForSeconds(1f);
        Menu.OpenPlayerSelectMenu();
    }

    public void ReturnToLastScreen()
    {
        StartCoroutine(ResetBeforeExiting());
    }

    private void UpdateButtonFunctions(Turn turn)
    {
        NextButton.onClick.RemoveAllListeners();
        BackButton.onClick.RemoveAllListeners();
        if (turn.Equals(Turn.TeamOne))
        {
            NextButton.onClick.AddListener(PlayerOneSet);
            BackButton.onClick.AddListener(ReturnToLastScreen);
        }
        else
        {
            NextButton.onClick.AddListener(PlayerTwoSet);
            BackButton.onClick.AddListener(PlayerOneReset);
        }
    }
}
