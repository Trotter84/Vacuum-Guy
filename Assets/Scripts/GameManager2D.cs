using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager2D : MonoBehaviour
{
    public Camera mainCamera;
    private int level;
    public GameObject title;
    public GameObject level_0;
    public GameObject level_1;
    public GameObject level_2;
    public GameObject level_3;
    private SpawnManager2D spawnManager2D;


    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (mainCamera == null)
        {
            Debug.LogError("mainCamera is NULL.");
        }

        mainCamera.transform.position = new Vector3(0, 0, -10);
    }

    public void LevelComplete()
    {
        FindRoom();
    }

    public void FindRoom()
    {
        spawnManager2D = GameObject.Find("Spawn_Manager2D").GetComponent<SpawnManager2D>();

        if (level_0.activeInHierarchy)
        {
            level = 0;
            NextRoom();
        }
        else if (level_1.activeInHierarchy)
        {
            level = 1;
            NextRoom();
        }
        else if (level_2.activeInHierarchy)
        {
            level = 2;
        }
        spawnManager2D.LoadLevel(level);
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
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelComplete();
            GameObject.Find("Player").GetComponent<PlayerController2D>().ResetPlayer();
            GameObject.Find("Text (TMP)").GetComponent<UpdateCollectibleCount2D>().Reset();
        }
    }
}
