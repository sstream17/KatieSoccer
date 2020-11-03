using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public bool IsMoving { get; private set; } = false;

    private float threshold = 0.001f;
    private const int noMovementFrames = 3;
    Vector3[] previousLocations = new Vector3[noMovementFrames];

    public void SetStartingPositions()
    {
        for (int i = 0; i < previousLocations.Length; i++)
        {
            previousLocations[i] = transform.position;
        }
    }

    void Awake()
    {
        SetStartingPositions();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < previousLocations.Length - 1; i++)
        {
            previousLocations[i] = previousLocations[i + 1];
        }
        previousLocations[previousLocations.Length - 1] = transform.position;

        for (int i = 0; i < previousLocations.Length - 1; i++)
        {
            if (Vector3.Distance(previousLocations[i], previousLocations[i + 1]) >= threshold)
            {
                //The minimum movement has been detected between frames
                IsMoving = true;
                break;
            }
            else
            {
                IsMoving = false;
            }
        }
    }
}
