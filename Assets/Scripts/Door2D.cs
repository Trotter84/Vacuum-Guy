using UnityEngine;


public class Door2D : MonoBehaviour
{
    private Animator doorAnim;


    void Start()
    {
        doorAnim = GetComponent<Animator>();
        if (doorAnim == null)
        { 
            Debug.LogError("doorAnim is NULL");
        }
    }

    public void OpenDoor()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        // doorAnim.SetTrigger("OnLevelComplete");
    }
}
