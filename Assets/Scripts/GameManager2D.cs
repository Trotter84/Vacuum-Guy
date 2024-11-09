using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2D : MonoBehaviour
{
    public Camera mainCamera;
    private string room_;
    // private int roomNumber = 0;
    public GameObject title;
    public GameObject room_0;
    public GameObject room_1;
    public GameObject room_2;
    // public int currentLevel;


    void Start()
    {
        // mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        mainCamera.transform.position = new Vector3(0, 0, -10);

        // title = GameObject.Find("Title");

        // room_0 = GameObject.Find("Room_0");
        // if (room_0 == null)
        // {
        //     Debug.Log("Room_0 is NULL.");
        // }
        // room_1 = GameObject.Find("Room_1");
        // if (room_1 == null)
        // {
        //     Debug.Log("Room_1 is NULL.");
        // }
        // room_2 = GameObject.Find("Room_2");
        // if (room_2 == null)
        // {
        //     Debug.Log("Room_2 is NULL.");
        // }

        // Debug.Log($"Level: {roomNumber}");

        
        // room_ = "Room_" + roomNumber;
        // Debug.Log(room_);

        // FindNextRoom();


        // int currentLevel = SceneManager.GetActiveScene().buildIndex;
        // Debug.Log($"Current Level is: {currentLevel}");
    }

    public void LevelComplete()
    {
        // ChangeRoom();
        
        room_1.SetActive(true);
        // mainCamera.transform.position = new Vector3(0, -9.41f, -10);
        title.SetActive(false);
        room_0.SetActive(false);

        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel == 0)
        {
            Debug.Log("Loading New Game...");
            // SceneManager.LoadScene(currentLevel += 1);
        }
        else
        {
            currentLevel += 1;
            Debug.Log($"Loading Level {currentLevel}");
            // SceneManager.LoadScene(currentLevel);
        }
    }

    // void FindNextRoom()
    // {
    //     level = GameObject.Find(room_).GetComponent<GameObject>();
    //     if (level == null)
    //     {
    //         Debug.Log("level is NULL.");
    //     }

    //     Debug.Log($"Level: {level}");
    // }

    // private void ChangeRoom()
    // {
    //     roomNumber += 1;
    //     level = GameObject.Find($"{room_}").GetComponent<GameObject>();
    // }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelComplete();
            GameObject.Find("Player").GetComponent<PlayerController2D>().ResetPlayer();
            GameObject.Find("Text (TMP)").GetComponent<UpdateCollectibleCount2D>().Start();
        }
    }
}
