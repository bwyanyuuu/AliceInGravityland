using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    [SerializeField] float bounceForce = 10f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "OVRCameraRig")
        {
            collision.rigidbody.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
        }
    }
}
