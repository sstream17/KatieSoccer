using System;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject[] TeamOnePieces;
    public GameObject[] TeamTwoPieces;
    public GameObject Ball;
    public Scoreboard Scoreboard;
    public LevelTransition LevelTransition;

    public enum Team { TeamOne = -1, TeamTwo = 1 };

    private GameObject[] allPieces;
    private Vector3[] startingPositions;
    private Team currentTurn;
    private bool piecesMoving = false;
    private bool piecesWereMoving = false;

    private int scoreToWin = 3;
    private int teamOneScore = 0;
    private int teamTwoScore = 0;
    private bool endGame = false;

    public void SetStartingPositions()
    {
        for (int i = 0; i < allPieces.Length; i++)
        {
            startingPositions[i] = allPieces[i].transform.position;
        }
    }

    void Awake()
    {
        Scoreboard.TeamOneName.text = GameData.TeamOneName;
        Scoreboard.TeamTwoName.text = GameData.TeamTwoName;
        scoreToWin = GameData.ScoreToWin;

        int numberOfAllPieces = TeamOnePieces.Length + TeamTwoPieces.Length + 1;
        allPieces = new GameObject[numberOfAllPieces];

        int iterator = 0;
        foreach (GameObject piece in TeamOnePieces)
        {
            allPieces[iterator] = piece;
            iterator = iterator + 1;
        }

        foreach (GameObject piece in TeamTwoPieces)
        {
            allPieces[iterator] = piece;
            iterator = iterator + 1;
        }

        allPieces[iterator] = Ball;

        startingPositions = new Vector3[allPieces.Length];

        SetStartingPositions();
    }

    // Start is called before the first frame update
    void Start()
    {
        Array values = Enum.GetValues(typeof(Team));
        int randomIndex = Mathf.FloorToInt(UnityEngine.Random.Range(0f, values.Length));
        currentTurn = (Team)values.GetValue(randomIndex);
        OnNextTurn();
    }

    // Update is called once per frame
    void Update()
    {
        piecesMoving = !PiecesStoppedMoving(allPieces);
        if (piecesMoving)
        {
            piecesWereMoving = true;
            DisablePieceInteraction(TeamOnePieces);
            DisablePieceInteraction(TeamTwoPieces);
        }
        
        if (!piecesMoving && piecesWereMoving)
        {
            piecesWereMoving = false;
            ChangeTurn();
            StopAllPieces();
            OnNextTurn();
        }
    }

    private void ChangeTurn()
    {
        int nextTurn = (int)currentTurn * -1;
        currentTurn = (Team)nextTurn;
    }

    private bool PiecesStoppedMoving(GameObject[] pieces)
    {
        foreach (GameObject piece in pieces)
        {
            PieceMovement pieceMovement = piece.GetComponent<PieceMovement>();
            if (pieceMovement.IsMoving)
            {
                return false;
            }
        }
        return true;
    }

    public void StopAllPieces()
    {
        foreach (GameObject piece in allPieces)
        {
            Rigidbody rb = piece.GetComponent<Rigidbody>();
            rb.Sleep();
        }
    }

    public void EnablePieceInteraction(GameObject[] pieces)
    {
        foreach (GameObject piece in pieces)
        {
            PieceInteraction pieceInteraction = piece.GetComponent<PieceInteraction>();
            pieceInteraction.enabled = true;
        }
    }

    public void DisablePieceInteraction(GameObject[] pieces)
    {
        foreach (GameObject piece in pieces)
        {
            PieceInteraction pieceInteraction = piece.GetComponent<PieceInteraction>();
            pieceInteraction.enabled = false;
        }
    }

    public void IlluminatePieces(GameObject[] pieces)
    {
        foreach (GameObject piece in pieces)
        {
            PieceAnimation pieceAnimation = piece.GetComponent<PieceAnimation>();
            pieceAnimation.IlluminatePieceLight();
        }
    }

    public void DarkenPieces(GameObject[] pieces)
    {
        foreach (GameObject piece in pieces)
        {
            PieceAnimation pieceAnimation = piece.GetComponent<PieceAnimation>();
            pieceAnimation.DarkenPieceLight();
        }
    }

    public void OnNextTurn()
    {
        if (currentTurn.Equals(Team.TeamOne))
        {
            DarkenPieces(TeamTwoPieces);
            DisablePieceInteraction(TeamTwoPieces);
            IlluminatePieces(TeamOnePieces);
            EnablePieceInteraction(TeamOnePieces);
        }
        else
        {
            DarkenPieces(TeamOnePieces);
            DisablePieceInteraction(TeamOnePieces);
            IlluminatePieces(TeamTwoPieces);
            EnablePieceInteraction(TeamTwoPieces);
        }
    }

    public void ResetAllPiecesToStart()
    {
        for (int i = 0; i < allPieces.Length; i++)
        {
            allPieces[i].transform.position = startingPositions[i];
        }
    }

    public void OnGoalScored(Team scoringTeam)
    {
        Scoreboard.DisplayMessage("Goal!");
        StopAllPieces();
        AddToScore(scoringTeam);
        Scoreboard.UpdateScoreboard(teamOneScore, teamTwoScore);
        Time.timeScale = 0f;
    }

    public void OnPostGoal()
    {
        if (endGame)
        {
            LevelTransition.FadeToNextLevel();
        }

        if (teamOneScore >= scoreToWin)
        {
            OnWin(Team.TeamOne);
        }
        else if (teamTwoScore >= scoreToWin)
        {
            OnWin(Team.TeamTwo);
        }
        else
        {
            Scoreboard.HideMessage();
            ResetAllPiecesToStart();
            ChangeTurn();
            Time.timeScale = 1f;
        }
    }

    public void OnWin(Team winningTeam)
    {
        endGame = true;
        StartCoroutine(Scoreboard.ShuffleMessage(winningTeam.ToString()));
    }

    private void AddToScore(Team scoringTeam)
    {
        if (scoringTeam.Equals(Team.TeamOne))
        {
            teamOneScore = teamOneScore + 1;
        }
        else
        {
            teamTwoScore = teamTwoScore + 1;
        }
    }
}
