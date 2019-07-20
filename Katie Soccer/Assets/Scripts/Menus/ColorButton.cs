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
            case "BlueButton":
                Image.color = PieceColors.Blue;
                break;
            case "PinkButton":
                Image.color = PieceColors.Pink;
                break;
            case "PurpleButton":
                Image.color = PieceColors.Purple;
                break;
            case "YellowButton":
                Image.color = PieceColors.Yellow;
                break;
            case "GreenButton":
                Image.color = PieceColors.Green;
                break;
            case "OrangeButton":
                Image.color = PieceColors.Orange;
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
