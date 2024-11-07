using UnityEngine;


public class Door2D : MonoBehaviour
{
    private Animator doorAnim;


    void Start()
    {
        doorAnim = GameObject.Find("Door_Bottom").GetComponent<Animator>();
        if (doorAnim == null)
        { 
            Debug.LogError("doorAnim is NULL");
        }
    }

    public void OpenDoor()
    {
        doorAnim.SetTrigger("OnLevelComplete");
    }
}
