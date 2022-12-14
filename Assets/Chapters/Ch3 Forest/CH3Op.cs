using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CH3Op : MonoBehaviour
{
    public GameObject bubble;
    public GameObject bubble_new;
    public GameObject player;
    private bool isEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayableDirector>().state == PlayState.Paused && !isEnabled)
        {
            TimelineEnd();
        }
    }
    public void TimelineEnd()
    {
        isEnabled = true;
        gameObject.GetComponent<PlayableDirector>().enabled = false;
        bubble.SetActive(false);
        bubble_new.SetActive(true);
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<ZeroGravity>().enabled = true;
        

    }
}
