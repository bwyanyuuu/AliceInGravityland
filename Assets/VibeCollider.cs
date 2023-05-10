using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeCollider : MonoBehaviour
{
    public List<int> pattern = new List<int>();
    public TestPattern testPattern;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("env")) {
            testPattern.MultipleVibration(pattern, 100, 0.2f);
            // print(other.name);
        }
    }
}