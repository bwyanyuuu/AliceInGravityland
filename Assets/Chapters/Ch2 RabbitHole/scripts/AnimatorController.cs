using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            // AnimatorManager.Instance.PlayAnim(anim, 1f);//一倍速播放
            anim.SetFloat("speed", 1.0f);
        }
        
        else if(Input.GetKeyDown(KeyCode.F))
        {
            // AnimatorManager.Instance.PlayAnim(anim, -1f);//一倍速倒放
            anim.SetFloat("speed", -1.0f);
        }
        
        else if(Input.GetKeyDown(KeyCode.G))
        {
            anim.SetFloat("speed", 0.0f);
        }

    }
}
