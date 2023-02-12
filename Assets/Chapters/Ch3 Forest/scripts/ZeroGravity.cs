using UnityEngine;
using System;
using Oculus.Interaction;
using UnityEditor;

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
    [SerializeField] CustomTactileMotionPattern hapticsManager;

    GameObject mushroom;
    Rigidbody _rigidbody;
    float _cooldownTimer;
    float _hapticsCooldownTimer;

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

    private float getEndAngle(float startAngle) {
        float endAngle = startAngle + 180.0f;
        if (endAngle < -180.0f) { endAngle += 360.0f; }
        else if (endAngle > 180.0f) { endAngle -= 360.0f; }
        return endAngle;
    }

    private void generateDragHaptics(float direction) {
        hapticsManager.TactileMotionDebugger(true, direction, getEndAngle(direction));
        hapticsManager.TactileMotionDebugger(false, direction, getEndAngle(direction));
    }

    private void Update() {
        float distanceToMushroom = Vector3.Distance(_rigidbody.transform.position, mushroom.transform.position);
        if (distanceToMushroom > 10.0f) {
            swimForce = 24.0f;
            dragForce = 1.0f;
        }
        else {
            swimForce = 18.0f;
            dragForce = 1.2f;
        }
    }

    void FixedUpdate()
    {
        Vector3 rigidBodyDirection = _rigidbody.transform.forward.normalized;
        Vector3 CameraDirection = cameraReference.transform.forward.normalized;
        Debug.DrawLine(transform.position, transform.position + rigidBodyDirection, Color.red);
        Debug.DrawLine(transform.position, transform.position + CameraDirection, Color.blue);
        //Debug.Log("StartAngle = " + _angularDifference);
        //Debug.Log("EndAngle = " + getEndAngle(_angularDifference));

        var leftHandDelta = leftHandReference.PointerPose.position - previousPositionLeft;
        leftHandVelocity = leftHandDelta / Time.deltaTime;
        previousPositionLeft = leftHandReference.PointerPose.position;

        var rightHandDelta = rightHandReference.PointerPose.position - previousPositionRight;
        rightHandVelocity = rightHandDelta / Time.deltaTime;
        previousPositionRight = rightHandReference.PointerPose.position;

        _cooldownTimer += Time.fixedDeltaTime;
        _hapticsCooldownTimer += Time.fixedDeltaTime;

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
                float hapticsOrigin = Vector3.SignedAngle(worldVelocity, CameraDirection, Vector3.up) * 0.5f - 10;
                hapticsOrigin = Math.Min(Math.Max(hapticsOrigin, -45), 45);
                // Debug.Log("ANGLE" + hapticsOrigin);
                if (_hapticsCooldownTimer >= 1.0) {
                    generateDragHaptics(hapticsOrigin);
                    _hapticsCooldownTimer = 0;
                }
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
