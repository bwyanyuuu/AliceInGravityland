using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationTest : MonoBehaviour
{
    [SerializeField] CustomTactileMotionPattern hapticsScript1;
    [SerializeField] TestPattern hapticsScript2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            // hapticsScript2.AllVibration(40, 1.0f);
            hapticsScript1.DoubleTactileMotionSample();
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            hapticsScript2.MultipleVibration(new List<int> { 0, 1,2, 14, 15 }, 80, 0.25f);
           
        }

    }
}
