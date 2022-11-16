using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poker : MonoBehaviour
{
    private AnimatorClipInfo clip;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        clip = gameObject.GetComponent<AnimatorClipInfo>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(clip.clip.name == "blank")
        {
            animator.enabled = false;
        }
    }
}
