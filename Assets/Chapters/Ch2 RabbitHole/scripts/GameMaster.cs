using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public enum Section
    {
        op,
        start,
        mirrorBroke,
        roomB,
        // may be somthing else
        backToA,
        ed
    }
    public Section section;
    public bool isDebug;

    [Header("GameObjects")]
    public GameObject op;
    public GameObject player;
    public GameObject handGesture;
    public GameObject poker;
    public GameObject pokerStack;
    public GameObject[] roomA;
    public GameObject[] roomB;
    public GameObject[] roomAAfter1;
    public GameObject[] roomAAfter2;
    public GameObject tutorial;
    public GameObject mirrorNormal;
    public GameObject mirrorBreak;
    public GameObject clock;
    public GameObject mirrorCollider;
    public GameObject chandelier;
    

    [Header("Controllers")]
    public bool nxt = false;
    public RotateRoom rotateRoom;
    
    private bool isSet = false;
    public bool intoRoomB = false;


    // Start is called before the first frame update
    void Start()
    {
        if(!isDebug) section = Section.op;
        pokerStack.SetActive(false);
        activeSet(roomA, false);
        activeSet(roomB, false);
        activeSet(roomAAfter1, false);
        activeSet(roomAAfter2, false);
        tutorial.SetActive(false);
        mirrorNormal.SetActive(false);
        mirrorBreak.SetActive(false);
        clock.SetActive(false);
        mirrorCollider.SetActive(false);
        op.SetActive(false);
        rotateRoom.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (section == Section.op)
        {
            if(!isSet){
                op.SetActive(true);
                activeSet(roomA, true);
                pokerStack.SetActive(true);
                mirrorNormal.SetActive(true);
                isSet = true;
            }
            if(nxt){
                op.SetActive(false);
                isSet = false;
                nxt = false;
                section = Section.start;
            }            
        }
        if (section == Section.start)
        {
            if(isDebug){
                activeSet(roomA, true);
                pokerStack.SetActive(true);
                mirrorNormal.SetActive(true);
            }   
            if(!isSet) tutorial.SetActive(true);
            if (nxt)
            {
                isSet = false;
                nxt = false;
                section = Section.mirrorBroke;
            } 
        }
        if(section == Section.mirrorBroke)
        {
            if (!isSet)
            {
                // if (isDebug) rotateRoom.up();
                mirrorCollider.SetActive(false);
                handGesture.SetActive(false);
                Destroy(poker);
                mirrorNormal.SetActive(false);
                mirrorBreak.SetActive(true);
                activeSet(roomA, false);
                activeSet(roomB, true);
                activeSet(roomAAfter1, true);
                clock.SetActive(true);
                chandelier.SetActive(false);
                Invoke("back", 15f);
                isSet = true;
            }
            if (nxt)
            {
                isSet = false;
                nxt = false;
                section = Section.backToA;
            }
        }
        if(section == Section.backToA)
        {
            if (!isSet)
            {
                activeSet(roomAAfter1, false);
                activeSet(roomAAfter2, true);
                activeSet(roomB, false);
                mirrorBreak.SetActive(false);
                mirrorCollider.SetActive(false);
                Invoke("backMirror", 3f);
                clock.SetActive(false);
                rotateRoom.rotate(0, new Vector3(0f, 0f, 0f)); // turn gavaity back to normal
                isSet = true;
            }
            if (nxt)
            {
                isSet = false;
                nxt = false;
                section = Section.ed;
            }
     
        }
    }
    void activeSet(GameObject[] list, bool b)
    {
        for(int i = 0; i < list.Length; i++)
        {
            list[i].SetActive(b);
        }
    }
    void back(){
        mirrorCollider.SetActive(true);
        mirrorCollider.GetComponent<BackToA>().isBack = true;
        for(int i = 0; i < mirrorBreak.transform.childCount; i++)
        {
            mirrorBreak.transform.GetChild(i).GetComponent<Collider>().enabled = true;
        }
    }
    private void backMirror()
    {
        mirrorNormal.SetActive(true);
    }
}
