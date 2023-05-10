using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public GameObject room;
    public bool pocketclockStart=false;
    public float roomScale;
    public bool anime;
    public float speed;
    private RotateRoom rotateRoom;
    private bool mirrorbroke=false;
    private GameMaster gameMaster;
    public GameObject mirror;
    public GameObject camera;
    private BoxCollider collider;
    // int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        rotateRoom = room.GetComponent<RotateRoom>();
        anim.SetFloat("speed", 0.0f);
        collider = gameObject.GetComponent<BoxCollider>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(roomBigger());
        }
        if(anime){
            if (!mirrorbroke)
            {
                if (rotateRoom.ChandelierFloor)
                {
                    anim.Play("Scene", 0, 0.0f);
                    anim.SetFloat("speed", 1.0f);
                    pocketclockStart = true;
                    mirrorbroke = true;
                    // gameMaster.nxt = true;
                }
            }
            anime = false;
        }
        collider.center = new Vector3(camera.transform.localPosition.x, 0.8447914f, camera.transform.localPosition.z + 0.2f);
    }
    void OnCollisionEnter(Collision collision)
    {
        //print(collision.collider.name);
        if (collision.collider.name == "Plane")
        {
            Debug.Log("floor");
            if (rotateRoom.RotateTime >= 3)
            {
                rotateRoom.ChandelierFloor = true;
                
                //print(gameObject.name+" set true "+rotateRoom.RotateTime);
            }
        }
        // f
        //if (collision.collider.CompareTag("cookie")){
        //    collision.collider.gameObject.SetActive(false);
        //    StartCoroutine(roomBigger());
        //}
        if (collision.collider.name == "mirror physical") 
        {
            print("player mirror physical");
        }
    }
    IEnumerator roomBigger()
    {
        //print("big");
        Vector3 pos = transform.position;
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        float step = roomScale / speed;
        float stepMirror = (23.93f - mirror.transform.position.y) / speed;
        for (int i = 0; i < speed; i++)
        {
            room.transform.localScale += new Vector3(step, step, step);
            transform.position = pos * (1 + i * step);
            mirror.transform.position = new Vector3(mirror.transform.position.x, mirror.transform.position.y + stepMirror, mirror.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
