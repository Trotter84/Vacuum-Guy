using UnityEngine;
using TMPro;
using System; // Required for Type handling

public class UpdateCollectibleCount2D : MonoBehaviour
{
    private float counter;
    private decimal timePassed;
    private int totalCollectibles;
    private TextMeshProUGUI collectibleText;
    private Door2D door2D;
    private VFXLevelComplete2D floatUpVFXEffect;

    
    public void Start()
    {
        door2D = GameObject.Find("Door_Bottom").GetComponent<Door2D>();
        if (door2D == null)
        {
            Debug.LogWarning("Door is NULL.");
        }

        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }
        UpdateCollectibleDisplay();
        // Debug.Log($"Collectible Count: {totalCollectibles}");
        // Debug.Log($"Time Passed: {timePassed}");
    }

    void Update()
    {
        timePassed = Math.Round((decimal)(counter += Time.deltaTime), 2);
        UpdateCollectibleDisplay();
        AllCollectablesGathered();
        // Debug.LogWarning($"Time Passed: {timePassed}");
    }

    private void UpdateCollectibleDisplay()
    {
        totalCollectibles = 0;
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }

        collectibleText.text = $"Collectibles remaining: {totalCollectibles}";
    }

//TODO: Set is true for level complete to remove it from Update()

    void AllCollectablesGathered()
    {
        // floatUpVFXEffect = GameObject.Find("VFX_Level_Complete").GetComponent<VFXLevelComplete2D>();
        // if (floatUpVFXEffect == null)
        // {
        //     Debug.LogError("FloatUp VFX is NULL.");
        // }
        
        if (timePassed > 1 && totalCollectibles == 0)
        {
            door2D.OpenDoor();
            // floatUpVFXEffect.Start();
            collectibleText.text = $"Level complete!";
        }
    }

    public void Reset()
    {
        Start();
    }
}
