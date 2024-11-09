using UnityEngine;


public class Collectible2D : MonoBehaviour
{
    public float rotationSpeed = 0.7f;
    public GameObject onCollectEffect;


    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.GetComponent<PlayerController2D>() != null) {
            
            Destroy(gameObject);

            GameObject particleEffect = Instantiate(onCollectEffect, transform.position, transform.rotation);

            Destroy(particleEffect, 2f);
        }   
    }
}
