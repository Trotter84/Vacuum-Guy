using UnityEngine;
using System.Collections;


public class MainMenu2D : MonoBehaviour
{
    public float textDelay = 10f;
    public GameObject startHereText;
    public GameObject arrow;


    void Start()
    {
        StartCoroutine(StartHereTextRoutine());
    }

    IEnumerator StartHereTextRoutine()
    {
        yield return new WaitForSeconds(textDelay);
        startHereText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        arrow.SetActive(true);
    }
}
