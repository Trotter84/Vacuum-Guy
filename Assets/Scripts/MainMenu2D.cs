using UnityEngine;
using System.Collections;
using TMPro;
using Unity.Mathematics;


public class MainMenu2D : MonoBehaviour
{
    public float textDelay = 4f;
    public float arrowDelay = 0.5f;
    public bool levelComplete = false;
    public GameObject controls;
    public GameObject collectibeAccent;
    public GameObject startHereText;
    public GameObject arrow;
    private GameManager2D gameManager2D;


    void Start()
    {
        gameManager2D = GameObject.Find("Game_Manager2D").GetComponent<GameManager2D>();
        if (gameManager2D == null)
        {
            Debug.LogError("GameManager2D is NULL.");
        }

        if (controls == null)
        {
            Debug.LogError("Controls are NULL.");
        }

        if (collectibeAccent == null)
        {
            Debug.LogError("Collectibe Accent is NULL.");
        }

        if (startHereText == null)
        {
            Debug.LogError("Start Here Text are NULL.");
        }

        if (arrow == null)
        {
            Debug.LogError("Arrow is NULL");
        }

        controls.SetActive(true);
        collectibeAccent.SetActive(true);
    }

    public void LevelComplete(bool levelComplete)
    {
        if (levelComplete)
        {
            StartCoroutine(UIRoutine());
        }
    }

    IEnumerator UIRoutine()
    {
        yield return new WaitForSeconds(textDelay);
        startHereText.SetActive(true);
        yield return new WaitForSeconds(arrowDelay);
        arrow.SetActive(true);
    }
}
