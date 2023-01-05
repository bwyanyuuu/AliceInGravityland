using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log(collisionInfo);
    }
}
