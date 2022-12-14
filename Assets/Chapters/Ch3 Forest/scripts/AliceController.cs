using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceController : MonoBehaviour
{
    public Transform view;
    public float yDiff;
    public float xDiff;
    public float zDiff;
    private Vector3 posDiff;
    private void Start()
    {
        posDiff = new Vector3(0f, yDiff, 0f);
    }
    void Update()
    {
        //print(view.position + " " + transform.position+" "+ (view.position - transform.position));
        transform.position = new Vector3(view.position.x + xDiff, view.position.y + yDiff, view.position.z + zDiff);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, view.eulerAngles.y + 90f, transform.eulerAngles.z);
    }
}
