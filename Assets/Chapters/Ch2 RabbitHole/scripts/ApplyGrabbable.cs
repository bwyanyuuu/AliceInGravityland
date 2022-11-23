using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyGrabbable : MonoBehaviour
{
    public GameObject grab;
    public GameObject target;
    public GameObject to;
    // Start is called before the first frame update
    void Start()
    {
        print(target.transform.childCount);
        //GameObject[] t = target.transform.GetChild
        for(int i = 0; i < target.transform.childCount; i++)
        {
            var g = GameObject.Instantiate(grab, to.transform);
            var c = target.transform.GetChild(0);
            g.name = c.name;
            c.transform.parent = g.transform;
            g.transform.position = new Vector3(c.transform.position.x, c.transform.position.y, c.transform.position.z);
            g.transform.rotation = new Quaternion(c.transform.rotation.x, c.transform.rotation.y, c.transform.rotation.z, c.transform.rotation.w);
            g.transform.localScale = new Vector3(c.transform.localScale.x, c.transform.localScale.y, c.transform.localScale.z);
            c.transform.localPosition = new Vector3(0f, 0f, 0f);
            c.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            c.transform.localScale = new Vector3(1f, 1f, 1f);
            
            var o = g.GetComponent<Oculus.Interaction.TouchHandGrabInteractable>();
            o._boundsCollider = c.GetComponent<BoxCollider>();
            o._colliders.Add(c.GetComponent<BoxCollider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
