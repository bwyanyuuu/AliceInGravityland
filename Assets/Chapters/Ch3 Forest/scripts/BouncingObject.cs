using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    [SerializeField] float bounceForce = 10f;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision detected1");
        collision.rigidbody.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
        if (collision.gameObject.tag == "OVRCameraRig" || collision.gameObject.tag == "Sphere")
        {
            Debug.Log("collision detected2");
            collision.rigidbody.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
        }
    }
}
