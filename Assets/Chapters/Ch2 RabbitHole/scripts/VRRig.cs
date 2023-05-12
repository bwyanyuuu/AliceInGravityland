using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap 
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffest;

    public void Map() 
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffest);
    }
}

public class VRRig : MonoBehaviour
{
    public VRMap Head;
    public VRMap RightHand;
    public VRMap LeftHand;
    public Transform headConstrain;
    public Vector3 headBodyOffect;
    // Start is called before the first frame update
    void Start()
    {
        headBodyOffect = transform.position - headConstrain.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = headConstrain.position + headBodyOffect;
        transform.forward = Vector3.ProjectOnPlane(headConstrain.up, Vector3.up).normalized;

        Head.Map();
        RightHand.Map();
        LeftHand.Map();
    }
}
