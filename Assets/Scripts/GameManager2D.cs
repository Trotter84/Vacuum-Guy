using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2D : MonoBehaviour
{
    public int currentLevel;


    void Start()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log($"Current Level is: {currentLevel}");
    }

    public void LevelComplete()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel == 0)
        {
            Debug.Log("Loading New Game...");
            SceneManager.LoadScene(currentLevel += 1);
        }
        else
        {
            currentLevel += 1;
            Debug.Log($"Loading Level {currentLevel}");
            SceneManager.LoadScene(currentLevel);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelComplete();
        }
    }
}
