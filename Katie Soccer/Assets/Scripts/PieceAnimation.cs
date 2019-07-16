using UnityEngine;

public class PieceAnimation : MonoBehaviour
{
    public Animator SelectionAnimator;
    public LineRenderer Arrow;
    public Vector3 ArrowDirection;
    public float MaxArrowLength = 1.5f;

    // Update is called once per frame
    void Update()
    {
        Arrow.SetPosition(1, ArrowDirection);
    }

    public void PieceSelected()
    {
        SelectionAnimator.SetTrigger("Selected");
        SelectionAnimator.ResetTrigger("Deselected");
        SelectionAnimator.ResetTrigger("Launched");
    }

    public void PieceDeselected()
    {
        SelectionAnimator.SetTrigger("Deselected");
        SelectionAnimator.ResetTrigger("Selected");
        SelectionAnimator.ResetTrigger("Launched");
    }

    public void PieceLaunched()
    {
        SelectionAnimator.SetTrigger("Launched");
        SelectionAnimator.ResetTrigger("Selected");
        SelectionAnimator.ResetTrigger("Deselected");
    }

    public void DrawArrow()
    {
        Arrow.enabled = true;
    }

    public void HideArrow()
    {
        Arrow.enabled = false;
    }
}
