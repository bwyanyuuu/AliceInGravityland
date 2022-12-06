using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DoorAnimation : MonoBehaviour
{
    private GameMaster gameMaster;
    public GameObject player;
    public GameObject bigdoor;
    public GameObject wall;
    private Vector3 OriginRotate;
    // Start is called before the first frame update
    void Start()
    {
        // player.transform.parent = null;
        // player.transform.SetParent(this.transform, true);
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        player.transform.position = new Vector3(4.0f, 0.25f, 2.518f);
        player.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);    
    }

    // Update is called once per frame
    void Update()
    {
        // if (timeline.GetComponent<PlayableDirector>().state == PlayState.Paused)
        // {
        //     // player.transform.SetParent(GameObject.Find("House").transform, true);
            
        // }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bigdoor.transform.rotation = Quaternion.Euler(-90.0f,0.0f,0.0f);
            wall.GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("House").GetComponent<RotateRoom>().enabled = true;
            gameMaster.nxt = true;
            
        }
    }
}
