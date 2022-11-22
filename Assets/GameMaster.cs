using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public enum Section
    {
        start,
        poker1,
        poker2,
        poker3,
        room2,
        clocPicked
    }
    public Section section;

    [Header("GameObjects")]
    public GameObject[] pokers;
    public GameObject[] tutorials;
    public GameObject[] roomA;
    public GameObject[] roomB;

    [Header("APIs")]
    public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        section = Section.start;
        activeSet(pokers, false);
        activeSet(tutorials, false);
        activeSet(roomB, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (section == Section.start)
        {
            pokers[0].SetActive(true);
            tutorials[0].SetActive(true);
            section = Section.poker1;
        }
        if (section == Section.poker1)
        {
            if (isTriggered)
            {
                pokers[1].SetActive(true);
                isTriggered = false;
                section = Section.poker2;
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
