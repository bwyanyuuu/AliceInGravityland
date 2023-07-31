using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float lineWidth = .2f;
    private Vector3 offset = new Vector3(0, 0, 0);

    public Transform origin;
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
        offset.x = -0.2f;
        offset.y = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(origin.position)
        lineRenderer.SetPosition(0, origin.position - offset);
        lineRenderer.SetPosition(1, destination.position);
    }
}
