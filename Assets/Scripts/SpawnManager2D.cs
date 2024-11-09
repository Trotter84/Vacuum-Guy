using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject dirt2DPrefab;
    public GameObject cheese2DPrefab;
    public GameObject star2DPrefab;
    public GameObject catPrefab;
    public GameObject dogPrefab;
    public GameObject petPrefab;
    private GameObject collectibleText;


    Vector2[] level1CollectablePositions =
    {
        // new Vector2(0.43f, 0.68f),
        // new Vector2(-0.3f, 2.4f),
        // new Vector2(-6.81f, 3.22f),
        // new Vector2(-2.63f, 2.06f),
        // new Vector2(-0.3f, 2.4f),
        // new Vector2(-5.76f, 1.5f),
        // new Vector2(-4.77f, -0.1f),
        // new Vector2(-2.25f, 0.68f),
        // new Vector2(-6.32f, -1.82f),
        // new Vector2(-5.12f, -3.51f),
        // new Vector2(2.71f, -2.98f),
        // new Vector2(0.3f, -3.26f),
        // new Vector2(-0.45f, -3.26f),
        // new Vector2(-1.2f, -3.26f),
        // new Vector2(-1.95f, -3.26f),
        // new Vector2(-2.7f, -3.26f),
        // new Vector2(-3.45f, -3.26f),
        // new Vector2(-3.949999f, -2.76f),
        // new Vector2(-4.449999f, -2.26f),
        // new Vector2(-4.949999f, -1.76f),
        // new Vector2(-5.449999f, -1.26f),
        // new Vector2(-5.949999f, -0.76f),
        // new Vector2(5.89f, -1.63f),
        // new Vector2(-0.57f, -0.66f),
        // new Vector2(1.39f, 2.1f),
        // new Vector2(6.79f, 2.12f),
        // new Vector2(6.79f, 1.62f),
        // new Vector2(6.79f, 1.12f),
        // new Vector2(6.79f, 0.6199999f),
        // new Vector2(6.79f, 0.1199999f),
        // new Vector2(6.29f, 0.1199999f),
        // new Vector2(5.79f, 0.1199999f),
        // new Vector2(5.29f, 0.1199999f),
        // new Vector2(4.79f, 0.1199999f),
        // new Vector2(4.29f, 0.1199999f),
        // new Vector2(3.79f, 0.1199999f),
        // new Vector2(3.29f, 0.1199999f),
        // new Vector2(2.62f, 3.2f),
        // new Vector2(4.77f, 2.89f),
        // new Vector2(3.27f, 1.76f),
        // new Vector2(4.96f, 1.49f),
        // new Vector2(-4.09f, 2.37f),
        // new Vector2(-2.61f, -1.22f),
        // new Vector2(3.82f, -3.24f),
        // new Vector2(4.67f, -3.14f),
        // new Vector2(3.85f, -1.65f),
        // new Vector2(4.89f, -1.44f),
        // new Vector2(2.69f, -1.54f),
    };

    // Vector2[] pushableObjectsPositions = 
    // {
    //     new Vector2(0, 0),
    // };

    void Start()
    {
        foreach (var collectable in level1CollectablePositions)
        {
            GameObject newCollectable = Instantiate(dirt2DPrefab, collectable, transform.rotation);
            newCollectable.transform.parent = gameObject.transform;
        }
        SpawnPet();
    }

    void SpawnPet()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 0)
        {
            int petPick = Random.Range(0, 2);

            switch (petPick)
            {
                case 0:
                    petPrefab = catPrefab;
                    break;
                case 1:
                    petPrefab = dogPrefab;
                    break;
            }
            Instantiate(petPrefab, new Vector3(0, -1.5f, 0), transform.rotation);
        }
    }
}
