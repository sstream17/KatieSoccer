using UnityEngine;

public class PieceAnimation : MonoBehaviour
{
    public static Animator SelectionAnimator;

    void Awake()
    {
        SelectionAnimator = GameObject
            .Find("SelectedIndicator")
            .GetComponent<Animator>();
    }

    public static void PieceSelected()
    {
        SelectionAnimator.SetTrigger("Selected");
        SelectionAnimator.ResetTrigger("Deselected");
        SelectionAnimator.ResetTrigger("Launched");
    }

    public static void PieceDeselected()
    {
        SelectionAnimator.SetTrigger("Deselected");
        SelectionAnimator.ResetTrigger("Selected");
        SelectionAnimator.ResetTrigger("Launched");
    }

    public static void PieceLaunched()
    {
        SelectionAnimator.SetTrigger("Launched");
        SelectionAnimator.ResetTrigger("Selected");
        SelectionAnimator.ResetTrigger("Deselected");
    }
}
