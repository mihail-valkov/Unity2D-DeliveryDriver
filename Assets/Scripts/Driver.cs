using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.3f;
    [SerializeField] float _defaultSpeed = 5f;
    [SerializeField] float _boostSpeed = 9f;

    private bool _isSpeedBoosted;

    Transform _speedBoostTag;
    float moveSpeed = 5f;

    public bool IsSpeedBoosted 
    { 
        get { return _isSpeedBoosted; }
    }

    public void Boost()
    {
        _isSpeedBoosted = true;
        this.moveSpeed = _boostSpeed;
        _speedBoostTag.gameObject.SetActive(true);
    }

    public void ResetSpeed()
    {
        _isSpeedBoosted = false;
        this.moveSpeed = _defaultSpeed;
        _speedBoostTag.gameObject.SetActive(false);
        
    }

    void Awake()
    {
        _speedBoostTag = transform.Find("SpeedBoostTag");
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetSpeed();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ResetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -Math.Sign(moveAmount) * steerAmount);

        //make the car move forward and back 
        transform.Translate(0, moveAmount, 0);
    }
}
