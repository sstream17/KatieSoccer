using UnityEngine;

public class PieceAnimation : MonoBehaviour
{
    public Animator SelectionAnimator;
    public LineRenderer Arrow;
    public Vector3 ArrowDirection;
    public float MaxArrowLength = 1.5f;
    public Animator LightAnimator;

    // Update is called once per frame
    void Update()
    {
        Arrow.SetPosition(1, ArrowDirection);
    }

    public void PieceSelected()
    {
        SelectionAnimator.ResetTrigger("Deselected");
        SelectionAnimator.ResetTrigger("Launched");
        SelectionAnimator.SetTrigger("Selected");
    }

    public void PieceDeselected()
    {
        SelectionAnimator.ResetTrigger("Selected");
        SelectionAnimator.ResetTrigger("Launched");
        SelectionAnimator.SetTrigger("Deselected");
    }

    public void PieceLaunched()
    {
        SelectionAnimator.ResetTrigger("Selected");
        SelectionAnimator.ResetTrigger("Deselected");
        SelectionAnimator.SetTrigger("Launched");
    }

    public void DrawArrow()
    {
        Arrow.enabled = true;
    }

    public void HideArrow()
    {
        Arrow.enabled = false;
    }

    public void IlluminatePieceLight()
    {
        LightAnimator.SetTrigger("Illuminate");
        LightAnimator.ResetTrigger("Darken");
    }

    public void DarkenPieceLight()
    {
        LightAnimator.SetTrigger("Darken");
        LightAnimator.ResetTrigger("Illuminate");
    }
}
