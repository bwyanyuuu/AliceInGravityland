using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public GameObject room;
    public bool pocketclockStart=false;
    public float roomScale;
    private RotateRoom rotateRoom;
    private bool mirrorbroke=false;
    private GameMaster gameMaster;
    // int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        rotateRoom = room.GetComponent<RotateRoom>();
        anim.SetFloat("speed", 0.0f);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(roomBigger());
        }
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
                    gameMaster.nxt = true;
                }
            }
            
        }
        if (collision.collider.CompareTag("cookie")){
            collision.collider.gameObject.SetActive(false);
            StartCoroutine(roomBigger());
        }
    }
    IEnumerator roomBigger()
    {
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        float step = roomScale / 60;
        for(int i = 0; i < 60; i++)
        {
            room.transform.localScale += new Vector3(step, step, step);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
