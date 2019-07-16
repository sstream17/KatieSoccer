using UnityEngine;

public class PieceInteraction : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 200f;
    public float SpeedClamp = 3f;

    private bool isSelected = false;
    private float triggerOffset = 0.3f;
    private bool launchable = false;
    private Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (isSelected)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetVector = mousePosition - transform.position;
            targetVector.z = 0f;
            if (targetVector.magnitude >= triggerOffset)
            {
                PieceAnimation.PieceSelected();
                launchable = true;
            }
            else
            {
                PieceAnimation.PieceDeselected();
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
            if (launchable)
            {
                launchable = false;
                PieceAnimation.PieceLaunched();
                rb.AddForce(Vector3.ClampMagnitude(targetVector, SpeedClamp) * -Speed);
            }
            else
            {
                PieceAnimation.PieceDeselected();
            }
        }
    }
}
