using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _objectToFollow;
    [SerializeField] private float _cameraZOffset = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Make the camera that would follow MaxDash object
        if (_objectToFollow != null)
        {
            Vector3 pos = _objectToFollow.transform.position;
            pos.z = _cameraZOffset;
            transform.position = pos;
        }
    }
}
