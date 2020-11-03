using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameScript GameScript;
    public GameScript.Team ScoringTeam;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Ball"))
        {
            GameScript.OnGoalScored(ScoringTeam);
        }
    }
}
