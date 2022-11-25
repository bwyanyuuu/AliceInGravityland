using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DoorAnimation : MonoBehaviour
{
    public GameObject player;
    public GameObject timeline;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.parent = null;
        player.transform.SetParent(this.transform, false);
        player.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);    

    }

    // Update is called once per frame
    void Update()
    {
        if (timeline.GetComponent<PlayableDirector>().state == PlayState.Paused)
        {
            player.transform.SetParent(GameObject.Find("House").transform, true);
            wall.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
