using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class GroundNormalRotator : MonoBehaviour
{
    public OVRCameraRig CameraRig;
    private Rigidbody _rigidbody;
    private Vector3 _groundNormalVector;
    private float _hapticsCooldownTimer;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float gravityForce;

    [SerializeField] CustomTactileMotionPattern hapticsScript1;
    [SerializeField] TestPattern hapticsScript2;
    
    void Start()
    {
        _rigidbody = transform.root.GetComponent<Rigidbody>();
        _groundNormalVector = transform.up;
        Physics.gravity = - gravityForce * _groundNormalVector;
    }

    void Update() {
        if (Input.GetKeyDown("space")) {
            hapticsScript2.AllVibration(40, 1.0f);
            hapticsScript1.DoubleTactileMotionSample();
        }
    }

    private void FixedUpdate()
    {
        FollowCameraRotation();  // detect the wall which is in-front-of the player
        SetGroundNormal();  // update the normal vector of the ground
        StandOnGroundRotation();  // rotate, so the character is normal to the ground
        SetGravityDirection();  // setting the gravity direction in physics engine to the reverse direction of the ground normal vector 
    }

    private void FollowCameraRotation()
    {
        Quaternion worldCameraRotation = CameraRig.centerEyeAnchor.rotation;
        transform.rotation = worldCameraRotation;
    }

    private void SetGroundNormal()
    {
        const float maxRayDistance = 3f;
        _groundNormalVector = Vector3.zero;

        foreach (var groundCheck in groundChecks)
        {
            Vector3 origin = groundCheck.position;
            Vector3 direction = -groundCheck.transform.up;
            if (Physics.Raycast(origin, direction, out RaycastHit hit, maxRayDistance, groundLayer))
            {
                _groundNormalVector += hit.normal;
            }
        }
        _groundNormalVector = _groundNormalVector.normalized;
    }

    private void StandOnGroundRotation()
    {
        Vector3 currentDir = _rigidbody.transform.up;
        Vector3 targetDir = _groundNormalVector;
        targetDir = Vector3.Lerp(currentDir, targetDir, Time.fixedDeltaTime * rotationSpeed);
        _rigidbody.MoveRotation(Quaternion.FromToRotation(currentDir, targetDir) * _rigidbody.rotation);
    }

    private void SetGravityDirection()
    {
        Vector3 gravityDirection = -_groundNormalVector;

        _hapticsCooldownTimer += Time.fixedDeltaTime;
        bool isGravityChanging = Vector3.Dot(gravityDirection.normalized, Physics.gravity.normalized) != 1;
        if (_hapticsCooldownTimer > 3.0f && isGravityChanging) {
            hapticsScript1.DoubleTactileMotionSample();
            hapticsScript2.AllVibration(20, 1.0f);
            _hapticsCooldownTimer = 0;
        }

        Physics.gravity = gravityForce * gravityDirection;
    }
}
