using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandelierCollider : MonoBehaviour
{
    public Animator anim;
    public GameObject room;
    public bool pocketclockStart=false;
    private RotateRoom rotateRoom;
    private bool mirrorbroke=false;
    // int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        rotateRoom = room.GetComponent<RotateRoom>();
        anim.SetFloat("speed", 0.0f);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Plane")
        {
            // Debug.Log("floor");
            if (rotateRoom.RotateTime >= 5)
            {
                rotateRoom.ChandelierFloor = true;
                // Debug.Log("set true");
            }
        }
        if (collision.collider.name == "mirror_glass")
        {
            // Debug.Log("mirror");
            // Debug.Log(rotateRoom.ChandelierFloor);
            if (!mirrorbroke)
            {
                if (rotateRoom.ChandelierFloor)
                {
                    anim.Play("Scene", 0, 0.0f);
                    anim.SetFloat("speed", 1.0f);
                    pocketclockStart = true;
                    mirrorbroke = true;
                }
            }
            
        }
    }
}
