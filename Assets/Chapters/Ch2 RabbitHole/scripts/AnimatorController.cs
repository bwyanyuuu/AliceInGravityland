using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    
    public Animator anim;
    public GameObject chandelierCollider;
    public GameObject knob;//旋轉鈕
    public GameObject clock;
    float i = 50.0f;
    float KnobAngle = 0.0f;
    Vector3 konbposition = new Vector3(0.0f, 0.0f, 0.0f);
    float KnobAngle_x = 0.0f;
    float KnobAngle_y = 0.0f;

    //float ClockAngle = 0.0f;
    Vector3 Clockposition;
    Vector3 ClockAngle;
    Vector3 diffAngle;
    //float ClockAngle_x = 0.0f;
    //float ClockAngle_y = 0.0f;
    public bool isTouching = false;
    private ChandelierCollider chandelier;

    void Start()
    {
        // anim.speed = 0f;
        
        chandelier = chandelierCollider.GetComponent<ChandelierCollider>();
        KnobAngle = knob.transform.localEulerAngles.z;
        konbposition = knob.transform.localPosition;
        KnobAngle_x = knob.transform.localEulerAngles.x;
        KnobAngle_y = knob.transform.localEulerAngles.y;
        diffAngle = clock.transform.eulerAngles - knob.transform.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.K))
        // {
        //     Debug.Log(knob.transform.eulerAngles.z);
        // }

        if (chandelier.pocketclockStart && isTouching)
        {
            
            knob.transform.localPosition = konbposition;
            knob.transform.localEulerAngles = new Vector3(KnobAngle_x, KnobAngle_y, knob.transform.localEulerAngles.z);
            if (knob.transform.localEulerAngles.z- KnobAngle > 0)
            {
                if (knob.transform.localEulerAngles.z- KnobAngle < 180.0f)
                {
                    perframe(anim, i);
                    i = i + 0.002f* (knob.transform.localEulerAngles.z- KnobAngle)*1.5f;
                    KnobAngle = knob.transform.localEulerAngles.z;
                    if(i > 1.0f) i = 1.0f;
                }
                else
                {
                    KnobAngle = knob.transform.localEulerAngles.z;
                }
                
            }
            if (knob.transform.localEulerAngles.z- KnobAngle < 0)
            {
                if (knob.transform.localEulerAngles.z- KnobAngle > -180.0f)
                {
                    perframe(anim, i);
                    i = i - 0.002f * (KnobAngle - knob.transform.localEulerAngles.z)*1.5f;
                    KnobAngle = knob.transform.localEulerAngles.z;
                    if(i < 0.0f) i = 0.0f;
                }
                else
                {
                    KnobAngle = knob.transform.localEulerAngles.z;
                }
            }

            // if (knob.transform.eulerAngles.z- KnobAngle == 0)
            // {
            //     anim.SetFloat("speed", 0.0f);
            // }
        }
    }
    


    public void perframe(Animator anim, float idx){
        anim.Play("Scene",0,idx);
        anim.SetFloat("speed", 0.0f);
    }


    public void touch(bool status)
    {
        isTouching = status;
        if (status)
        {
            KnobAngle = knob.transform.localEulerAngles.z;
            konbposition = knob.transform.localPosition;
            KnobAngle_x = knob.transform.localEulerAngles.x;
            KnobAngle_y = knob.transform.localEulerAngles.y;
        }
    }
}
