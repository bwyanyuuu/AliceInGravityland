using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private static AnimatorManager _instance;

    public static AnimatorManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    //播放动画anim(速度为speed)
    public void PlayAnim(Animator anim, float speed)
    {
        if(anim!=null)
        {
            anim.enabled = true;
            AnimatorClipInfo[] temps = anim.GetCurrentAnimatorClipInfo(0);
            AnimatorClipInfo clipInfo = new AnimatorClipInfo();
            if(temps.Length>0)
            {
                clipInfo = temps[0];//获取动画clip
            }
            anim.StartPlayback();
            anim.speed = speed;
            anim.Play(clipInfo.clip.name, 0, speed < 0 ? 1 : 0);
        }
    }

    //暂停动画anim
    public void StopAnim(Animator anim)
    {
        AnimatorClipInfo[] temps = anim.GetCurrentAnimatorClipInfo(0);
        AnimatorClipInfo clipInfo = new AnimatorClipInfo();
        if(temps.Length>0)
        {
            clipInfo = temps[0];
        }
        anim.Play(clipInfo.clip.name, 0, 0);
        anim.speed = 0;
    }

}
