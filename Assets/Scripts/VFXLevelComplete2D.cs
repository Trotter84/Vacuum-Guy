using UnityEngine;

public class VFXLevelComplete2D : MonoBehaviour
{
    public GameObject floatUpVFXPrefab;

    public void Start()
    {
        Instantiate(floatUpVFXPrefab, transform.position, transform.rotation);
    }
}
