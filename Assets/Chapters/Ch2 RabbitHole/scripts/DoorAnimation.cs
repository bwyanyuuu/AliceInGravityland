using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public GameObject player;
    // public GameObject AnimPlayer;
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
        
    }
}
