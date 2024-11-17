using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager2D : MonoBehaviour
{
    public bool isLevelCompleted = false;
    public Camera mainCamera;
    public int level;
    public GameObject title;
    public GameObject level_0;
    public GameObject level_1;
    public GameObject level_2;
    public GameObject level_3;
    public GameObject level_4;
    public GameObject level_5;
    private SpawnManager2D spawnManager2D;
    private MainMenu2D mainMenu2D;


    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (mainCamera == null)
        {
            Debug.LogError("mainCamera is NULL.");
        }

        mainCamera.transform.position = new Vector3(0, 0, -10);
        FindRoom();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.LogWarning("Quitting game...");
            Application.Quit();
        }
    }

    public void LevelComplete()
    {
        if (level == 0)
        {
            mainMenu2D = GameObject.Find("Main_Menu").GetComponent<MainMenu2D>();
            mainMenu2D.LevelComplete(true);
        }
    }

    void FindRoom()
    {
        spawnManager2D = GameObject.Find("Spawn_Manager2D").GetComponent<SpawnManager2D>();

        if (level_0.activeInHierarchy)
        {
            level = 0;
        }
        else if (level_1.activeInHierarchy)
        {
            level = 1;
        }
        else if (level_2.activeInHierarchy)
        {
            level = 2;
        }
        else if (level_3.activeInHierarchy)
        {
            level = 3;
        }
        else if (level_4.activeInHierarchy)
        {
            level = 4;
        }
        else if (level_5.activeInHierarchy)
        {
            level = 5;
        }

        spawnManager2D.Spawn(level);
    }

    void NextRoom()
    {
        switch (level)
        {
            case 0:
                level++;
                Debug.Log($"Loading level {level}...");
                level_1.SetActive(true);
                level_0.SetActive(false);
                break;
            case 1:
                level++;
                Debug.Log($"Loading level {level}...");
                level_2.SetActive(true);
                level_1.SetActive(false);
                break;
            case 2:
                level++;
                Debug.Log($"Loading level {level}...");
                level_3.SetActive(true);
                level_2.SetActive(false);
                break;
            case 3:
                level++;
                Debug.Log($"Loading level {level}...");
                level_4.SetActive(true);
                level_3.SetActive(false);
                break;
            case 4:
                level++;
                Debug.Log($"Loading level {level}...");
                level_5.SetActive(true);
                level_4.SetActive(false);
                break;
            case 5:
                level++;
                Debug.Log($"Game Over...");
                

                break;

        }
        spawnManager2D.Spawn(level);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NextRoom();
            GameObject.Find("Player").GetComponent<PlayerController2D>().ResetPlayer();
            GameObject.Find("Text (TMP)").GetComponent<UpdateCollectibleCount2D>().Reset();
        }
    }
}
