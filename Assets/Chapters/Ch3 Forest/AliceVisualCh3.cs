using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AliceVisualCh3 : MonoBehaviour
{
    public OVRCameraRig CameraRig;
    private Transform _transformReference;
    private Vector3 _localPositionOffset;
    private Vector3 _localRotationOffset;

    private Transform _selfTransform;
    [SerializeField] private Rigidbody _rigidbody;
    private int _isWalkingHash;


    private void Awake()
    {
        _selfTransform = transform;
        _localPositionOffset = _selfTransform.localPosition;
        _localRotationOffset = _selfTransform.localRotation.eulerAngles;
        _transformReference = CameraRig.centerEyeAnchor.transform;
    }

    void Start()
    {
        //_rigidbody = transform.root.GetComponent<Rigidbody>();
        _isWalkingHash = Animator.StringToHash("isWalking");
    }

    void Update()
    {
        // Local position & rotation follow camera 
        Vector3 localRotationRef = _transformReference.localRotation.eulerAngles;
        //float convertedYAngle = convertAngle(localRotationRef.y);
        //_selfTransform.localRotation = Quaternion.Euler(0f + _localRotationOffset.x,
                                                        //(convertedYAngle * .8f + _localRotationOffset.y),
                                                       // 0f + _localRotationOffset.z);
        _selfTransform.localRotation = Quaternion.Euler(0f + _localRotationOffset.x,
                                                (localRotationRef.y + _localRotationOffset.y),
                                                0f + _localRotationOffset.z);
        Vector3 localPositionRef = _transformReference.localPosition;
        _selfTransform.localPosition = localPositionRef + _localPositionOffset;
        
        
    }
    
    private bool CheckIsWalking()
    {
        bool result = false;
        const float threshold = 0.1f; 
        Vector3 velocity = _rigidbody.velocity;
        
        if (velocity.sqrMagnitude > threshold) {
            result = true;
        }
        return result;
    }

    private float convertAngle(float angle)
    {
        if (angle > 180f)
        {
            angle -= 360f;
        }

        return angle;
    }
}
