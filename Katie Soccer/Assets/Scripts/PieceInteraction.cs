using UnityEngine;

public class PieceInteraction : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 200f;
    public float SpeedClamp = 3f;
    public PieceAnimation PieceAnimation;

    private bool isSelected = false;
    private float triggerOffset = 0.3f;
    private float speedAdjust = 2f;
    private Vector3 arrow;
    private bool launchable = false;
    private Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetVector = mousePosition - transform.position;
            targetVector.z = 0f;
            arrow = new Vector3(targetVector.x, 0f, targetVector.y);
            PieceAnimation.ArrowDirection = Vector3.ClampMagnitude(-arrow, PieceAnimation.MaxArrowLength);
            if (targetVector.magnitude >= triggerOffset)
            {
                PieceAnimation.PieceSelected();
                PieceAnimation.DrawArrow();
                launchable = true;
            }
            else
            {
                PieceAnimation.PieceDeselected();
                PieceAnimation.HideArrow();
                launchable = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (this.enabled)
        {
            isSelected = true;
        }
    }

    private void OnMouseUp()
    {
        if (this.enabled)
        {
            isSelected = false;
            PieceAnimation.HideArrow();
            if (launchable)
            {
                launchable = false;
                PieceAnimation.PieceLaunched();
                rb.AddForce(Vector3.ClampMagnitude(targetVector * speedAdjust, SpeedClamp) * -Speed);
            }
            else
            {
                PieceAnimation.PieceDeselected();
            }
        }
    }
}
