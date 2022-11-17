using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poker : MonoBehaviour
{
    private AnimatorClipInfo clip;
    private Animator animator;
    private AnimatorStateInfo stateinfo;
    // Start is called before the first frame update
    void Start()
    {
        // clip = gameObject.GetComponent<AnimatorClipInfo>();
        animator = gameObject.GetComponent<Animator>();
        // animator.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // if(clip.clip.name == "blank")
        // {
        //     animator.enabled = false;
        // }

        // if (Input.GetKeyDown(KeyCode.B))
        // {
        //     animator.speed = 1.0f;
        //     animator.Play("poker_4",0,0.0f);
        //     Debug.Log("start");
        // }

        stateinfo = animator.GetCurrentAnimatorStateInfo(0); 
        if ((stateinfo.normalizedTime >= 1.0f) && (stateinfo.IsTag("Poker")))
        {
            // Debug.Log("end");
            animator.enabled = false;
        }
    }
}
