using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToA : MonoBehaviour
{
    private GameMaster gameMaster;
    private PlayerController playerController;
    private RotateRoom rotateRoom;
    private bool isAnime = false;
    public bool isBack = false;
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        playerController = GameObject.Find("OVRCameraRig_TouchGrab").GetComponent<PlayerController>();
        rotateRoom = GameObject.Find("House").GetComponent<RotateRoom>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if(!isAnime && rotateRoom.ChandelierFloor){
                playerController.anime = true;
                isAnime = true;
                gameMaster.nxt = true;

                print("mirror1");
                gameObject.SetActive(false);
            }
            else if(isAnime && isBack){
                gameMaster.nxt = true;
                print("mirror2");
            }
        }
    }

}
