using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip_SavePlayer : MonoBehaviour
{
    private GameMaster gameMaster;
    public GameObject player;
    public GameObject roomAcenter;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            player.transform.position = roomAcenter.transform.position;
        }
        if (Input.GetKeyDown("space"))
        {
            print("space");
            gameMaster.nxt = true;
        }
    }
}
