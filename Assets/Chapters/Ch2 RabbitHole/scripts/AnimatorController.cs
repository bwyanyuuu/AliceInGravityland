using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    
    public Animator anim;
    float i = 0.0f;

    void Start()
    {
        anim.speed = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            // AnimatorManager.Instance.PlayAnim(anim, 1f);//一倍速播放
            // anim.SetFloat("speed", 1.0f);
            perframe(anim, i);
            i = i + 0.02f;
            if(i > 1.0f) i = 1.0f;
            Debug.Log(i);
        }
        
        else if(Input.GetKeyDown(KeyCode.F))
        {
            // AnimatorManager.Instance.PlayAnim(anim, -1f);//一倍速倒放
            // anim.SetFloat("speed", -1.0f);
            perframe(anim, i);
            i = i - 0.02f;
            if(i < 0.0f) i = 0.0f;
            Debug.Log(i);
        }
        
        else if(Input.GetKeyDown(KeyCode.G))
        {
            anim.SetFloat("speed", 0.0f);
        }

    }
    public void perframe(Animator anim, float idx){
        anim.Play("Scene",0,idx);
        anim.SetFloat("speed", 0.0f);
    }
}
