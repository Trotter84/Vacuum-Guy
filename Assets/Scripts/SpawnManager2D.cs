using UnityEngine;

public class SpawnManager2D : MonoBehaviour
{
    public GameObject cheese2DPrefab;
    public GameObject dirt2DPrefab;
    public GameObject star2DPrefab;
    public GameObject catPrefab;
    public GameObject dogPrefab;
    public GameObject petPrefab;
    private int level;


    Vector2[] level0Collectibles =
    {
        new Vector2(2.38f, -1.66f),
    };

    Vector2[] level1Collectibles =
    {
        new Vector2(-5.96000004f, 1.66999996f),
        new Vector2(-2.06f, -1.81f),
        new Vector2(-4f, -3.41f),
        new Vector2(-1f, 2.7f),
        new Vector2(0.53f, 3.24f),
        new Vector2(2.07f, 3.48f),
        new Vector2(2.21f, -3.77f),
        new Vector2(3.87f, -3.52f),
        new Vector2(5.96000004f, 0f),
        new Vector2(-5.96000004f, -1.76999998f)
    };

    Vector2[] level2Collectibles =
    {
        new Vector2(4.09f, 3.87f),
        new Vector2(3.79f, 1.21f),
        new Vector2(-3.89f, -0.64f),
        new Vector2(-3.08f, -0.73f),
        new Vector2(-4.01f, -2.17f),
        new Vector2(-6.69f, -3.6f),
        new Vector2(1.23f, -2.03f),
        new Vector2(0.09f, -1.57f),
        new Vector2(-1.05f, -1.04f),
        new Vector2(-3f, 1.88f),
        new Vector2(-3.74f, 1.63f),
        new Vector2(3.49f, -1.71f),
        new Vector2(-6.88f, 3.54f),
        new Vector2(-6.14f, 0.81f),
        new Vector2(-1.21f, -3.82f),
    };

    Vector2[] levelXCollectibles =
    {
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
        new Vector2(0,0),
    };

    // Vector2[] level1PushableObjects = 
    // {
    //     new Vector2(0, 0),
    // };

    public void Spawn(int level)
    {
        PetPicker();
        SpawnObjects(level);
    }

    public void SpawnObjects(int level)
    {
        Debug.Log($"Spawning Collectibles for level {level}");
        switch (level)
        {
            case 0:
                foreach (var collectible in level0Collectibles)
                {
                    GameObject newCollectible = Instantiate(star2DPrefab, collectible, transform.rotation);
                    newCollectible.transform.parent = gameObject.transform;
                }
                GameObject newPet = Instantiate(petPrefab, new Vector2(-0.97f, -1.62f), Quaternion.Euler(0, 0, 45));
                newPet.transform.parent = gameObject.transform;
                break;
            case 1:
                foreach (var collectible in level1Collectibles)
                {
                    GameObject newCollectible = Instantiate(dirt2DPrefab, collectible, transform.rotation);
                    newCollectible.transform.parent = gameObject.transform;
                }
                newPet = Instantiate(petPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-4f, 4f)), Quaternion.Euler(0, 0, Random.Range(0, 360)));
                newPet.transform.parent = gameObject.transform;
                break;
            case 2:
                foreach (var collectible in level2Collectibles)
                {
                    GameObject newCollectible = Instantiate(dirt2DPrefab, collectible, transform.rotation);
                    newCollectible.transform.parent = gameObject.transform;
                }
                newPet = Instantiate(petPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-4f, 4f)), Quaternion.Euler(0, 0, Random.Range(0, 360)));
                newPet.transform.parent = gameObject.transform;
                break;
            case 3:
                foreach (var collectible in levelXCollectibles)
                {
                    GameObject newCollectible = Instantiate(cheese2DPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-4, 4)), transform.rotation);
                    newCollectible.transform.parent = gameObject.transform;
                }
                newPet = Instantiate(petPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-4f, 4f)), Quaternion.Euler(0, 0, 360));
                newPet.transform.parent = gameObject.transform;
                break;
            case 4:
                foreach (var collectible in levelXCollectibles)
                {
                    GameObject newCollectible = Instantiate(dirt2DPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-4, 4)), transform.rotation);
                    newCollectible.transform.parent = gameObject.transform;
                }
                newPet = Instantiate(petPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-4f, 4f)), Quaternion.Euler(0, 0, 360));
                newPet.transform.parent = gameObject.transform;
                break;
            case 5:
                foreach (var collectible in levelXCollectibles)
                {
                    GameObject newCollectible = Instantiate(dirt2DPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-4, 4)), transform.rotation);
                    newCollectible.transform.parent = gameObject.transform;
                }
                newPet = Instantiate(petPrefab, new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-4f, 4f)), Quaternion.Euler(0, 0, 360));
                newPet.transform.parent = gameObject.transform;
                break;
        }
    }

    void PetPicker()
    {
        int chanceForSpawn = Random.Range(0, 3);

        if (level == 0)
        {
            PetPickerSwitch();
        }
        else if (chanceForSpawn == 1)
        {
            PetPickerSwitch();
        }
    }

    void PetPickerSwitch()
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
    }
}
