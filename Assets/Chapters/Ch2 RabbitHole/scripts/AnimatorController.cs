using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    
    public Animator anim;
    public GameObject knob;//旋轉鈕
    float i = 0.0f;
    float KnobAngle = 0.0f;

    void Start()
    {
        anim.speed = 0f;
        KnobAngle = knob.transform.eulerAngles.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(knob.transform.eulerAngles.y);
        }
        if (knob.transform.eulerAngles.y - KnobAngle > 0)
        {
            perframe(anim, i);
            i = i + 0.002f* (knob.transform.eulerAngles.y - KnobAngle)*0.001f;
            if(i > 1.0f) i = 1.0f;
            Debug.Log(i);
        }
        if (knob.transform.eulerAngles.y - KnobAngle < 0)
        {
            perframe(anim, i);
            i = i - 0.002f * (knob.transform.eulerAngles.y - KnobAngle)*0.001f;
            if(i < 0.0f) i = 0.0f;
            Debug.Log(i);
        }
        if (knob.transform.eulerAngles.y - KnobAngle == 0)
        {
            anim.SetFloat("speed", 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // AnimatorManager.Instance.PlayAnim(anim, 1f);//一倍速播放
            // anim.SetFloat("speed", 1.0f);
            perframe(anim, i);
            i = i + 0.002f;
            if(i > 1.0f) i = 1.0f;
            Debug.Log(i);
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            // AnimatorManager.Instance.PlayAnim(anim, -1f);//一倍速倒放
            // anim.SetFloat("speed", -1.0f);
            perframe(anim, i);
            i = i - 0.002f;
            if(i < 0.0f) i = 0.0f;
            Debug.Log(i);
        }
        
        if(Input.GetKeyDown(KeyCode.G))
        {
            anim.SetFloat("speed", 0.0f);
        }

    }
    public void perframe(Animator anim, float idx){
        anim.Play("Scene",0,idx);
        anim.SetFloat("speed", 0.0f);
    }
}
