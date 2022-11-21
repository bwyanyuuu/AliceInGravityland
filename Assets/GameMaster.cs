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

    [Header("APIs")]
    public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        section = Section.start;
    }

    // Update is called once per frame
    void Update()
    {
        //if(section == Section.start)
        //{
        //    pokers[0].SetActive(true);
        //    section = Section.poker1;
        //}
        //if(section == Section.poker1)
        //{

        //}
    }
}
