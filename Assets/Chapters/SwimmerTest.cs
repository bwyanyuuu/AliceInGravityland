using UnityEngine;
using System;

public class SwimmerTest : MonoBehaviour
{
    [SerializeField] float swimForce = 10f;
    [SerializeField] float dragForce = 1f;
    [SerializeField] float minForce;
    [SerializeField] float minTimeBetweenStrokes;

    [SerializeField] OVRHand leftHandReference;
    [SerializeField] Vector3 leftHandVelocity;
    [SerializeField] Vector3 previousPositionLeft;
    [SerializeField] OVRHand rightHandReference;
    [SerializeField] Vector3 rightHandVelocity;
    [SerializeField] Vector3 previousPositionRight;

    [SerializeField] Transform leftHandVisual;
    [SerializeField] Transform rightHandVisual;

    [SerializeField] Transform trackingReference;
    [SerializeField] Transform cameraReference;

    Rigidbody _rigidbody;
    float _cooldownTimer;
    bool _isActiveRight;
    bool _isActiveLeft;
    Vector3 m_EulerAngleVelocity; // test

    Vector3 handsAnchor = new Vector3(0, 0, 0);

    public void setActiveRight(bool state)
    {
        _isActiveRight = state;
    }

    public void setActiveLeft(bool state)
    {
        _isActiveLeft = state;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        m_EulerAngleVelocity = new Vector3(0, 20, 0); // test

        _isActiveRight = false;
        _isActiveLeft = false;

        previousPositionLeft = leftHandReference.PointerPose.position;
        previousPositionRight = rightHandReference.PointerPose.position;
    }

    private float modulo(float x, float n)
    {
        return (float)(x - Math.Floor(x / n) * n);
    }

    void Update()
    {
        leftHandVisual.transform.position = handsAnchor;
        rightHandVisual.transform.position = handsAnchor;
        var rotationalDifference = transform.rotation.eulerAngles.y - cameraReference.transform.rotation.eulerAngles.y;

        //rotationalDifference = targetA - sourceA;
        rotationalDifference = modulo((rotationalDifference + 180), 360) - 180;
        //Debug.Log("Camera" + cameraReference.transform.rotation.eulerAngles.y);
        //Debug.Log("RigidBody" + transform.rotation.eulerAngles.y);

        if (rotationalDifference > 35) {
            Quaternion deltaRotation = Quaternion.Euler(-m_EulerAngleVelocity * (0.1f * rotationalDifference) * Time.fixedDeltaTime); // test
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation); // test
        }
        else if (rotationalDifference < -35)
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * (-0.1f * rotationalDifference) * Time.fixedDeltaTime); // test
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation); // test

        }
        else
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
    void FixedUpdate()
    {
        leftHandVelocity = (leftHandReference.PointerPose.position - previousPositionLeft) / Time.deltaTime;
        previousPositionLeft = leftHandReference.PointerPose.position;

        rightHandVelocity = (rightHandReference.PointerPose.position - previousPositionRight) / Time.deltaTime;
        previousPositionRight = rightHandReference.PointerPose.position;

        _cooldownTimer += Time.fixedDeltaTime;
        if (_cooldownTimer > minTimeBetweenStrokes
            && leftHandReference.GetFingerIsPinching(OVRHand.HandFinger.Index)
            && rightHandReference.GetFingerIsPinching(OVRHand.HandFinger.Index))
        //if (_cooldownTimer > minTimeBetweenStrokes
        //    && _isActiveRight
        //    && _isActiveLeft)
        {
            var leftHandVelocity = this.leftHandVelocity;
            var rightHandVelocity = this.rightHandVelocity;
            Vector3 localVelocity = leftHandVelocity + rightHandVelocity;
            localVelocity *= -1;

            if (localVelocity.sqrMagnitude > minForce * minForce)
            {
                Vector3 worldVelocity = trackingReference.TransformDirection(localVelocity);
                _rigidbody.AddForce(worldVelocity * swimForce, ForceMode.Acceleration);
                _cooldownTimer = 0;
            }
        }

        if (_rigidbody.velocity.sqrMagnitude > 2.00)
        {
            // Sets the viscosity (the higher, the more viscuous)
            _rigidbody.AddForce(-_rigidbody.velocity * dragForce, ForceMode.Acceleration);
        }
    }
}
