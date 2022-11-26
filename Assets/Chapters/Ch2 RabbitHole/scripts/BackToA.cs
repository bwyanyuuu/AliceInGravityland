using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToA : MonoBehaviour
{
    private GameMaster gameMaster;
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameMaster.nxt = true;
        }
    }

}
