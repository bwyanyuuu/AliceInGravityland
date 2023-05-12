using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    public GameObject camera;
    public float height;
    private CapsuleCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        collider.center = new Vector3(camera.transform.localPosition.x, height, camera.transform.localPosition.z + 0.2f);
    }
}
