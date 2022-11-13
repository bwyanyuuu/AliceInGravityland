using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    
    public Animator anim;
    public GameObject knob;//旋轉鈕
    float i = 0.0f;
    float KnobAngle = 0.0f;
    Vector3 konbposition = new Vector3(0.0f, 0.0f, 0.0f);
    float KnobAngle_x = 0.0f;
    float KnobAngle_y = 0.0f;

    void Start()
    {
        anim.speed = 0f;
        KnobAngle = knob.transform.eulerAngles.z;
        konbposition = knob.transform.position;
        KnobAngle_x = knob.transform.rotation.x;
        KnobAngle_y = knob.transform.eulerAngles.y;
    }
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.K))
        // {
        //     Debug.Log(knob.transform.eulerAngles.z);
        // }
        knob.transform.position = konbposition;
        knob.transform.eulerAngles = new Vector3(KnobAngle_x, KnobAngle_y, knob.transform.eulerAngles.z);
        if (knob.transform.eulerAngles.z- KnobAngle > 0)
        {
            if (knob.transform.eulerAngles.z- KnobAngle < 180.0f)
            {
                perframe(anim, i);
                i = i + 0.002f* (knob.transform.eulerAngles.z- KnobAngle)*1.5f;
                KnobAngle = knob.transform.eulerAngles.z;
                if(i > 1.0f) i = 1.0f;
            }
            else
            {
                KnobAngle = knob.transform.eulerAngles.z;
            }
            
        }
        if (knob.transform.eulerAngles.z- KnobAngle < 0)
        {
            if (knob.transform.eulerAngles.z- KnobAngle > -180.0f)
            {
                perframe(anim, i);
                i = i - 0.002f * (KnobAngle - knob.transform.eulerAngles.z)*1.5f;
                KnobAngle = knob.transform.eulerAngles.z;
                if(i < 0.0f) i = 0.0f;
            }
            else
            {
                KnobAngle = knob.transform.eulerAngles.z;
            }
        }

        if (knob.transform.eulerAngles.z- KnobAngle == 0)
        {
            anim.SetFloat("speed", 0.0f);
        }
    }


    public void perframe(Animator anim, float idx){
        anim.Play("Scene",0,idx);
        anim.SetFloat("speed", 0.0f);
    }

}
