using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    public void FadeToNextLevel()
    {
        FadeToLevel((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }


    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }


    public void OnFadeComplete()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelToLoad);
    }
}
