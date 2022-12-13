using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public GameObject wall;
    //public Animator sphere;
    //public LevelLoader cutScene;
    //private GameMaster gameMaster;
    //private bool ishahaed = false;
    // Start is called before the first frame update
    void Start()
    {
        //gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wall.GetComponent<Collider>().enabled = false;
        }
    }
}
