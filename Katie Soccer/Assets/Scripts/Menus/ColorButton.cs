using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public Button Button;
    public Image Image;
    public Animator Animator;
    public bool IsSelected = false;
    public TwoPlayerCustomization TwoPlayerCustomization;

    void Awake()
    {
        switch (Button.name)
        {
            case "RedButton":
                Image.color = PieceColors.Red;
                break;
            case "SolarButton":
                Image.color = PieceColors.Solar;
                break;
            case "OrangeButton":
                Image.color = PieceColors.Orange;
                break;
            case "PeachButton":
                Image.color = PieceColors.Peach;
                break;
            case "GoldButton":
                Image.color = PieceColors.Gold;
                break;
            case "YellowButton":
                Image.color = PieceColors.Yellow;
                break;
            case "LimeButton":
                Image.color = PieceColors.Lime;
                break;
            case "GreenButton":
                Image.color = PieceColors.Green;
                break;
            case "TealButton":
                Image.color = PieceColors.Teal;
                break;
            case "LightBlueButton":
                Image.color = PieceColors.LightBlue;
                break;
            case "BlueButton":
                Image.color = PieceColors.Blue;
                break;
            case "DarkBlueButton":
                Image.color = PieceColors.DarkBlue;
                break;
            case "PurpleButton":
                Image.color = PieceColors.Purple;
                break;
            case "LavenderButton":
                Image.color = PieceColors.Lavender;
                break;
            case "HotPinkButton":
                Image.color = PieceColors.HotPink;
                break;
            case "PinkButton":
                Image.color = PieceColors.Pink;
                break;
            case "WhiteButton":
                Image.color = PieceColors.White;
                break;
            case "SilverButton":
                Image.color = PieceColors.Silver;
                break;
            case "GrayButton":
                Image.color = PieceColors.Gray;
                break;
            case "BlackButton":
                Image.color = PieceColors.Black;
                break;
        }
    }

    public void OnSelected()
    {
        TwoPlayerCustomization.DeselectOtherColors();
        IsSelected = true;
        Animator.ResetTrigger("Deselected");
        Animator.SetTrigger("Selected");
    }

    public void OnDeselected()
    {
        IsSelected = false;
        Animator.ResetTrigger("Selected");
        Animator.SetTrigger("Deselected");
    }
}
