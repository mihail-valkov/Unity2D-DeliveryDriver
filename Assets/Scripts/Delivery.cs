using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0.5f;
    private bool packagePickedUp;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision with " + other.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //check if the object is tagged as Package or Customer
        if (!packagePickedUp && other.gameObject.CompareTag("Package"))
        {
            //Destroy the package
            Debug.Log("Package picked up!");
            //pick up a package
            packagePickedUp = true;
            //change the color of the car to indicate that the package color

            _spriteRenderer.color = other.gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(other.gameObject, destroyDelay);
        }
        else if (other.gameObject.CompareTag("Customer"))
        {
            //check if the package is picked up
            if (!packagePickedUp)
            {
                Debug.Log("No package picked up!");
                return;
            }
            Debug.Log("Delivered to customer!");
            //reset the color of the car
            GetComponent<SpriteRenderer>().color = Color.white;
            packagePickedUp = false;
            //Destroy the customer
            //Destroy(other.gameObject);
        }
    }
}
