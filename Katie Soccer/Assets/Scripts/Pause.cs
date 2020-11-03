﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public ScrollRect PauseMenu;
    public RectTransform Content;
    public Transform Scoreboard;
    public ExitModal ExitModal;
    public GameScript GameScript;
    public GameObject[] AllPieces;
    public LevelTransition LevelTransition;
    public static bool Paused = false;

    private Vector2 contentStartingPosition;
    private float contentHeight;
    private Vector2 scoreboardRestingPosition;
    private bool dragStarted = false;
    private bool letGo = true;
    

    void Start()
    {
        contentStartingPosition = Content.position;
        contentHeight = Content.rect.height;
        scoreboardRestingPosition = Scoreboard.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragStarted)
        {
            float distanceDragged = Scoreboard.position.y - scoreboardRestingPosition.y;
            if (letGo)
            {
                if (distanceDragged <= -400f)
                {
                    LerpToPosition(contentStartingPosition.y - contentHeight * 1.2f, 3f);
                    StartCoroutine(OnPause());
                }
                else
                {
                    LerpToPosition(contentStartingPosition.y, 20f);
                }
            }
        }
        else if (!Paused)
        {
            if (letGo)
            {
                LerpToPosition(contentStartingPosition.y, 8f);
            }
        }
    }

    private void LerpToPosition(float position, float speedModifier = 1f)
    {
        float newY = Mathf.Lerp(Content.position.y, position, Time.deltaTime * speedModifier);
        Vector2 newPosition = new Vector2(Content.position.x, newY);
        Content.position = newPosition;
    }

    public void DragStarted()
    {
        letGo = false;
        dragStarted = true;
    }

    public void DragEnded()
    {
        letGo = true;
    }

    IEnumerator OnPause()
    {
        while (Content.position.y > contentStartingPosition.y - contentHeight)
        {
            yield return new WaitForEndOfFrame();
        }
        GameScript.DisablePieceInteraction(AllPieces);
        Paused = true;
        Time.timeScale = 0f;
        dragStarted = false;
        PauseMenu.vertical = false;
    }

    IEnumerator Unpaused()
    {
        yield return new WaitForFixedUpdate();
        GameScript.SetUnpaused();
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        PauseMenu.vertical = true;
        Paused = false;
        GameScript.ReenablePieceInteraction();
        StartCoroutine(Unpaused());
    }

    public void OnRestart()
    {
        ExitModal.gameObject.SetActive(false);
        GameScript.StopAllPieces();
        GameScript.ResetScores();
        GameScript.ResetAllPiecesToStart();
        GameScript.GetRandomTurn();
        OnResume();
    }

    public void OnQuit()
    {
        Paused = false;
        LevelTransition.FadeToLevel(0);
    }

    public void PromptRestart()
    {
        ExitModal.SetMessage("Restart");
        ExitModal.SetExitButton(OnRestart);
        ExitModal.gameObject.SetActive(true);
    }

    public void PromptQuit()
    {
        ExitModal.SetMessage("Quit");
        ExitModal.SetExitButton(OnQuit);
        ExitModal.gameObject.SetActive(true);
    }
}
