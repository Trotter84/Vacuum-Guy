using UnityEngine;
using System.Collections;


//TODO: Try to fix Gravity!!

public class Gravity2D : MonoBehaviour {
    public bool isGravityPullActive = false;
    public float gravityStrength = 50f;
    public float abilityLength = 5f;
    GameObject[] movableObjects;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movableObjects = GameObject.FindGameObjectsWithTag("Movable_Object");
    }

    void FixedUpdate()
    {
        GravityCheck();
    }

    void GravityCheck()
    {
        if (isGravityPullActive)
        {
            foreach(GameObject b in movableObjects)
            {
                float m1 = rb.mass;
                float m2 = b.GetComponent<Rigidbody2D>().mass;
                float r = Vector2.Distance(rb.transform.position, b.transform.position);

                rb.GetComponent<Rigidbody2D>().AddForce((b.transform.position - rb.transform.position).normalized * (gravityStrength * (m1 * m2) / (r * r)));
                
            }
        }
    }

    public void ActivateGravity()
    {
        isGravityPullActive = true;
        StartCoroutine(GravityAbilityTimerRoutine());
    }

    IEnumerator GravityAbilityTimerRoutine()
    {
        yield return new WaitForSeconds(abilityLength);
        isGravityPullActive = false;
        yield return new WaitForSeconds(abilityLength);
    }
}


    
//     public Transform otherObject;
//     ContactPoint2D[] contacts;
//     Rigidbody2D objectBody;
//     public float influenceRange;
//     public float intensity;
//     public float distanceToObject;
//     Vector2 pullForce;

//     void Start()
//     {
//         influenceRange = GetComponent<CircleCollider2D>().radius;
//         objectBody = otherObject.GetComponent<Rigidbody2D>();
//         // List<MoveableObject> moveableObjects = new List<MoveableObject>();

//         // moveableObjects.Add(new MoveableObject("hello", 40));
//     }

//     void FixedUpdate()
//     {
        

//         distanceToObject = Vector2.Distance(objectBody.position, transform.position);
//         if (distanceToObject <= influenceRange)
//         {
//             pullForce = (transform.position - otherObject.position).normalized / distanceToObject * intensity;
//             objectBody.AddForce(pullForce, ForceMode2D.Force);
//         }
//     }
// //TODO: Get gravity working.
//     // void OnTriggerEnter2D(Collider2D collision)
//     // {
//     //     collision.GetContacts(contacts);
        
//     //     Debug.LogWarning(contacts);
//     // }