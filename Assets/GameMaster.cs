using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public enum Section
    {
        start,
        poker0,
        poker1,
        poker2,
        poker3,
        poker4,
        mirrorBroke,
        roomB,
        // may be somthing else
        backToA
    }
    public Section section;
    public bool isDebug;

    [Header("GameObjects")]
    public GameObject[] pokers;
    public GameObject[] tutorials;
    public GameObject[] roomA;
    public GameObject[] roomB;
    public GameObject[] roomAAfter1;
    public GameObject[] roomAAfter2;
    public GameObject mirrorNormal;
    public GameObject mirrorBreak;

    [Header("Controllers")]
    public bool nxt = false;
    public RotateRoom rotateRoom;
    
    private bool isSet = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!isDebug) section = Section.start;
        activeSet(pokers, false);
        activeSet(tutorials, false);
        activeSet(roomA, false);
        activeSet(roomB, false);
        activeSet(roomAAfter1, false);
        activeSet(roomAAfter2, false);
        mirrorBreak.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (section == Section.start)
        {
            activeSet(roomA, true);
            pokers[0].SetActive(true);
            tutorials[0].SetActive(true);
            section = Section.poker0;
        }
        if (section == Section.poker0)
        {
            if (nxt)
            {                
                nxt = false;
                section = Section.poker1;
            }
        }
        if (section == Section.poker1)
        {
            if (!isSet)
            {
                pokers[1].SetActive(true);
                isSet = true;
            }
            if (nxt)
            {
                isSet = false;
                nxt = false;
                section = Section.poker2;
            }
        }
        if (section == Section.poker2)
        {
            if (!isSet)
            {
                pokers[2].SetActive(true);
                isSet = true;
            }
            if (nxt)
            {
                isSet = false;
                nxt = false;
                section = Section.poker3;
            }
        }
        if (section == Section.poker3)
        {
            if (!isSet)
            {
                pokers[3].SetActive(true);
                isSet = true;
            }
            if (nxt)
            {
                isSet = false;
                nxt = false;
                section = Section.poker4;
            }
        }
        if(section == Section.poker4)
        {
            if (!isSet)
            {
                pokers[4].SetActive(true);
                isSet = true;
            }
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
                if (isDebug) rotateRoom.up();
                mirrorNormal.SetActive(false);
                mirrorBreak.SetActive(true);
                activeSet(roomA, false);
                activeSet(roomB, true);
                activeSet(roomAAfter1, true);
                isSet = true;
            }
            if (nxt)
            {
                isSet = false;
                nxt = false;
                // section = Section.roomB;
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
                mirrorNormal.SetActive(true);
                rotateRoom.rotate(0); // 回到A房間時把重力轉回去
                isSet = true;
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
}
