using UnityEngine;
using System;
using Oculus.Interaction;

public class ZeroGravity : MonoBehaviour
{
    [SerializeField] float swimForce = 15f;
    [SerializeField] float dragForce = 2f;
    [SerializeField] float minForce = 1.1f;
    [SerializeField] float minTimeBetweenStrokes;

    [SerializeField] OVRHand leftHandReference;
    [SerializeField] Vector3 leftHandVelocity;
    [SerializeField] Vector3 previousPositionLeft;
    [SerializeField] OVRHand rightHandReference;
    [SerializeField] Vector3 rightHandVelocity;
    [SerializeField] Vector3 previousPositionRight;

    [SerializeField] Transform trackingReference;
    [SerializeField] Transform cameraReference;
    
    Rigidbody _rigidbody;
    float _cooldownTimer;

    bool _poseActiveRight;
    bool _poseActiveLeft;
    
    public void setActiveRight(bool state)
    {
        _poseActiveRight = state;
    }

    public void setActiveLeft(bool state)
    {
        _poseActiveLeft = state;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        _poseActiveRight = false;
        _poseActiveLeft = false;

        previousPositionLeft = leftHandReference.PointerPose.position;
        previousPositionRight = rightHandReference.PointerPose.position;
    }

    void FixedUpdate()
    {
        Debug.DrawLine(transform.position,
            transform.position + _rigidbody.transform.forward.normalized,
            Color.red);
        Debug.DrawLine(transform.position,
            transform.position + cameraReference.transform.forward.normalized,
            Color.blue);

        var leftHandDelta = leftHandReference.PointerPose.position - previousPositionLeft;
        leftHandVelocity = leftHandDelta / Time.deltaTime;
        previousPositionLeft = leftHandReference.PointerPose.position;

        var rightHandDelta = rightHandReference.PointerPose.position - previousPositionRight;
        rightHandVelocity = rightHandDelta / Time.deltaTime;
        previousPositionRight = rightHandReference.PointerPose.position;

        _cooldownTimer += Time.fixedDeltaTime;

        if (_cooldownTimer > minTimeBetweenStrokes && _poseActiveRight && _poseActiveLeft)
        {
            var leftHandVelocity = this.leftHandVelocity;
            var rightHandVelocity = this.rightHandVelocity;
            Vector3 localVelocity = leftHandVelocity + rightHandVelocity;

            // Invert the direction of movement relative to the hands
            localVelocity *= -1;

            // Cross product of vector facing away from the player and hand movement vector
            // If below 0, hand movement is toward player so ignore it
            Vector3 cameraDirection = cameraReference.transform.forward;
            float direction = Vector3.Dot(localVelocity, cameraDirection);
            bool isMovingForward = direction >= 0;

            if (isMovingForward && localVelocity.sqrMagnitude > minForce * minForce)
            {
                Vector3 worldVelocity = trackingReference.TransformDirection(localVelocity);
                worldVelocity = Vector3.ClampMagnitude(worldVelocity, 10.0f);
                _rigidbody.AddForce(worldVelocity * swimForce, ForceMode.Acceleration);
                _cooldownTimer = 0;
            }
        }

        // Set the drag force
        if (_rigidbody.velocity.sqrMagnitude > 0.01)
        {
            _rigidbody.AddForce(-_rigidbody.velocity * dragForce, ForceMode.Acceleration);
        }
    }
}
