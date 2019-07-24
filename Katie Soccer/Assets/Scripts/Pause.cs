using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public ScrollRect PauseMenu;
    public RectTransform Content;
    public Transform Scoreboard;
    public GameScript GameScript;
    public GameObject[] AllPieces;
    public static bool Paused = false;

    private Vector2 contentStartingPosition;
    private float contentHeight;
    private Vector2 contentPreviousPosition;
    private Vector2 scoreboardRestingPosition;
    private bool dragStarted = false;
    private bool wasMoving = false;
    

    void Start()
    {
        contentStartingPosition = Content.position;
        contentHeight = Content.rect.height;
        contentPreviousPosition = contentStartingPosition;
        scoreboardRestingPosition = Scoreboard.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragStarted)
        {
            float distanceDragged = Scoreboard.position.y - scoreboardRestingPosition.y;
            if (distanceDragged <= -400f)
            {
                LerpToPosition(contentStartingPosition.y - contentHeight, 3f);
                StartCoroutine(OnPause());
            }
            else
            {
                LerpToPosition(contentStartingPosition.y, 20f);
            }
        }
        else if (!Paused)
        {
            LerpToPosition(contentStartingPosition.y, 8f);
        }

        wasMoving = (contentPreviousPosition.y - Content.position.y) >= 0.1f;
        contentPreviousPosition = Content.position;
    }

    private void LerpToPosition(float position, float speedModifier = 1f)
    {
        float newY = Mathf.Lerp(Content.position.y, position, Time.deltaTime * speedModifier);
        Vector2 newPosition = new Vector2(Content.position.x, newY);
        Content.position = newPosition;
    }

    public void DragStarted()
    {
        dragStarted = true;
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

    public void OnUnpause()
    {
        Time.timeScale = 1f;
        PauseMenu.vertical = true;
        Paused = false;
        GameScript.EnablePieceInteraction(AllPieces);
    }
}
