using UnityEngine;
using System;
using Oculus.Interaction;

public class ZeroGravity : MonoBehaviour
{
    [SerializeField] float swimForce = 10f;
    [SerializeField] float dragForce = 1f;
    [SerializeField] float minForce;
    [SerializeField] float minTimeBetweenStrokes;
    [SerializeField] float rotateSpeed;
    [SerializeField] float minRotateAngle;

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

    // Speed of Y-axis rotation
    //Vector3 m_EulerAngleVelocity = new Vector3(0, 20, 0);
    
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

    //private float modulo(float x, float n)
    //{
    //    return (float)(x - Math.Floor(x / n) * n);
    //}

    void Update()
    {   
        //// Adjust camera movement relative to player head rotation
        //var rotationalDifference = transform.rotation.eulerAngles.y - cameraReference.transform.rotation.eulerAngles.y;
        //rotationalDifference = modulo((rotationalDifference + 180), 360) - 180;

        //if (rotationalDifference > minRotateAngle) {
        //    Quaternion deltaRotation = Quaternion.Euler(-m_EulerAngleVelocity * rotateSpeed * (.8f * rotationalDifference) * Time.fixedDeltaTime);
        //    _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        //}
        //else if (rotationalDifference < -minRotateAngle)
        //{
        //    Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * rotateSpeed * (-.8f * rotationalDifference) * Time.fixedDeltaTime);
        //    _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);

        //}
        //else
        //{
        //    _rigidbody.angularVelocity = Vector3.zero;
        //}
    }
    void FixedUpdate()
    {
        leftHandVelocity = (leftHandReference.PointerPose.position - previousPositionLeft) / Time.deltaTime;
        previousPositionLeft = leftHandReference.PointerPose.position;

        rightHandVelocity = (rightHandReference.PointerPose.position - previousPositionRight) / Time.deltaTime;
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
