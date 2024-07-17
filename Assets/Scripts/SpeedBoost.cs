using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    Driver _driver;

    void Awake()
    {
        _driver = GetComponent<Driver>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (_driver.IsSpeedBoosted)
        {
            return;
        }

        //check if the object is tagged as SpeedBoost
        if (other.gameObject.CompareTag("SpeedBoostMark"))
        {
            //set the moveSpeed of the driver to 0.1f
            _driver.Boost();
            //destroy the speedboost object
            Destroy(other.gameObject);
        }
    }

    
}
