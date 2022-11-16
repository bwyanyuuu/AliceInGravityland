using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
//    private float agent;
// 	void Start () {
//         agent = 0f;
// 	}
	
// 	// Update is called once per frame
// 	void Update () {
//         agent += Time.deltaTime*50;
//         transform.rotation = Quaternion.Euler(new Vector3(0f,agent,0f));
// 	}
    public Transform center;
    public GameObject player;
    public GameObject camera;
    public Animator black;
    // public GameObject testbox;
    // bool startroatate=false;
    public GameObject Chandelier;
	//转动速度
	public float rotationSpeed=10;
    public int RotateTime=0;
    public bool ChandelierFloor=false;
    // public bool ChandelierMirror=false;
    private bool isRotating = false;
    
    private void Start()
    {
        
    }
    void Update() {
        //跟随center转圈圈
        // 面向+z軸
        //if (black.GetBool("start"))
        //{
        //    black.SetBool("start", false);
        //}
        //print(player.transform.forward);

        //站起來測試box
        // if (testbox.transform.right.y < 1.1f && testbox.transform.right.y > 0.9f){
        //     startroatate = true;
        // }
        // if (startroatate){
        //     testbox.transform.Rotate(new Vector3(0,0,-0.05f));
        // }
        if (RotateTime == 5)
        {
            // Rigidbody ChandelierRigidBody = Chandelier.AddComponent<Rigidbody>();
            // ChandelierRigidBody.useGravity = true;
            Chandelier.GetComponent<Rigidbody>().useGravity = true;
            Chandelier.GetComponent<Collider>().enabled = true;
        }
        // if (RotateTime >= 5)
        // {
        //     Debug.Log(ChandelierFloor);
        // }

        if (player.transform.eulerAngles.y%360 > 315.0f || player.transform.eulerAngles.y%360 < 45.0f){ 
            if (Input.GetKeyDown(KeyCode.W)){   
                this.transform.RotateAround(center.position, Vector3.forward, 180);
                RotateTime++;
            }
            if (Input.GetKeyDown(KeyCode.A)){   //吸到左邊(-x)
                this.transform.RotateAround(center.position, Vector3.forward, 90);  //以Z軸為中心逆時針轉90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.D)){   //吸到右邊(+x)
                this.transform.RotateAround(center.position, Vector3.forward, -90); //以Z軸為中心逆時針轉270(-90)
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.X)){   //吸到前面(+z)
                this.transform.RotateAround(center.position, Vector3.right, 90);    //以X軸為中心逆時針轉90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.C)){   //吸到後面(-z)
                this.transform.RotateAround(center.position, Vector3.right, -90);   //以X軸為中心逆時針轉-90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
        }
        // 面向-z軸
        if (player.transform.eulerAngles.y%360 >= 135.0f && player.transform.eulerAngles.y%360 < 225.0f){ 
            if (Input.GetKeyDown(KeyCode.W)){   
                this.transform.RotateAround(center.position, Vector3.forward, 180);
                RotateTime++;
            }
            if (Input.GetKeyDown(KeyCode.A)){   //吸到左邊(-x)
                this.transform.RotateAround(center.position, Vector3.forward, -90);  //以Z軸為中心逆時針轉-90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.D)){   //吸到右邊(+x)
                this.transform.RotateAround(center.position, Vector3.forward, 90);   //以Z軸為中心逆時針轉90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.X)){   //吸到前面(-z)
                this.transform.RotateAround(center.position, Vector3.right, -90);    //以X軸為中心逆時針轉-90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.C)){   //吸到後面(+z)
                this.transform.RotateAround(center.position, Vector3.right, 90);     //以X軸為中心逆時針轉90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
        }
        // 面向+x軸
        if (player.transform.eulerAngles.y%360 >= 45.0f && player.transform.eulerAngles.y%360 < 135.0f){ 
            if (Input.GetKeyDown(KeyCode.W)){   
                this.transform.RotateAround(center.position, Vector3.right, 180);
                RotateTime++;
            }
            if (Input.GetKeyDown(KeyCode.A)){   //吸到左邊(+z)
                this.transform.RotateAround(center.position, Vector3.right, 90);    //以X軸為中心逆時針轉90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.D)){   //吸到右邊(-z)
                this.transform.RotateAround(center.position, Vector3.right, -90);   //以X軸為中心逆時針轉-90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.X)){   //吸到前面(+x)
                this.transform.RotateAround(center.position, Vector3.forward, -90);  //以Z軸為中心逆時針轉-90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.C)){   //吸到後面(-x)
                this.transform.RotateAround(center.position, Vector3.forward, 90); //以Z軸為中心逆時針轉90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
        }
        // 面向-x軸
        if (player.transform.eulerAngles.y%360 >= 225.0f && player.transform.eulerAngles.y%360 < 315.0f){ 
            if (Input.GetKeyDown(KeyCode.W)){   
                this.transform.RotateAround(center.position, Vector3.right, 180);
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.A)){   //吸到左邊(-z)
                this.transform.RotateAround(center.position, Vector3.right, -90);    //以X軸為中心逆時針轉-90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.D)){   //吸到右邊(+z)
                this.transform.RotateAround(center.position, Vector3.right, 90);   //以X軸為中心逆時針轉90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.X)){   //吸到前面(-x)
                this.transform.RotateAround(center.position, Vector3.forward, 90);  //以Z軸為中心逆時針轉90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
            if (Input.GetKeyDown(KeyCode.C)){   //吸到後面(+x)
                this.transform.RotateAround(center.position, Vector3.forward, -90); //以Z軸為中心逆時針轉-90
                RotateTime++;
                if (ChandelierFloor) ChandelierFloor = false;
            }
        }
        
		
	}
    // void OnCollisionEnter(Collision collision)
    // {

    // }
    public void rotate(int i)
    {
        if (isRotating) return;
        else isRotating = true;
        float phase = camera.transform.eulerAngles.y;
        // print(phase);
        if (phase % 360 > 315.0f || phase % 360 < 45.0f)
        {
            switch (i)
            {
                case 0: // up
                    this.transform.RotateAround(center.position, Vector3.forward, 180);
                    StartCoroutine(rotatePlayer(90f, 0f, 0f));
                    RotateTime++;
                    break;
                case 1: // front
                    this.transform.RotateAround(center.position, Vector3.right, 90);    //以X軸為中心逆時針轉90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 2: // back
                    this.transform.RotateAround(center.position, Vector3.right, -90);   //以X軸為中心逆時針轉-90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 3: // left
                    this.transform.RotateAround(center.position, Vector3.forward, 90);  //以Z軸為中心逆時針轉90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 4: // right
                    this.transform.RotateAround(center.position, Vector3.forward, -90); //以Z軸為中心逆時針轉270(-90)
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                default:
                    break;
            }
        }
        // 面向-z軸
        if (phase % 360 >= 135.0f && phase % 360 < 225.0f)
        {
            switch (i)
            {
                case 0: // up
                    this.transform.RotateAround(center.position, Vector3.forward, 180);
                    StartCoroutine(rotatePlayer(90f, 0f, 0f));
                    RotateTime++;
                    break;
                case 1: // front
                    this.transform.RotateAround(center.position, Vector3.right, -90);    //以X軸為中心逆時針轉-90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 2: // back
                    this.transform.RotateAround(center.position, Vector3.right, 90);     //以X軸為中心逆時針轉90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 3: // left
                    this.transform.RotateAround(center.position, Vector3.forward, -90);  //以Z軸為中心逆時針轉-90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 4: // right
                    this.transform.RotateAround(center.position, Vector3.forward, 90);   //以Z軸為中心逆時針轉90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                default:
                    break;
            }
        }
        // 面向+x軸
        if (phase % 360 >= 45.0f && phase % 360 < 135.0f)
        {
            switch (i)
            {
                case 0: // up
                    this.transform.RotateAround(center.position, Vector3.forward, 180);
                    StartCoroutine(rotatePlayer(90f, 0f, 0f));
                    RotateTime++;
                    break;
                case 1: // front
                    this.transform.RotateAround(center.position, Vector3.forward, -90);  //以Z軸為中心逆時針轉-90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 2: // back
                    this.transform.RotateAround(center.position, Vector3.forward, 90); //以Z軸為中心逆時針轉90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 3: // left
                    this.transform.RotateAround(center.position, Vector3.right, 90);    //以X軸為中心逆時針轉90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 4: // right
                    this.transform.RotateAround(center.position, Vector3.right, -90);   //以X軸為中心逆時針轉-90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                default:
                    break;
            }
        }
        // 面向-x軸
        if (phase % 360 >= 225.0f && phase % 360 < 315.0f)
        {
            switch (i)
            {
                case 0: // up
                    this.transform.RotateAround(center.position, Vector3.forward, 180);
                    RotateTime++;
                    StartCoroutine(rotatePlayer(90f, 0f, 0f));
                    break;
                case 1: // front
                    this.transform.RotateAround(center.position, Vector3.forward, 90);  //以Z軸為中心逆時針轉90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 2: // back
                    this.transform.RotateAround(center.position, Vector3.forward, -90); //以Z軸為中心逆時針轉-90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 3: // left
                    this.transform.RotateAround(center.position, Vector3.right, -90);    //以X軸為中心逆時針轉-90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 4: // right
                    this.transform.RotateAround(center.position, Vector3.right, 90);   //以X軸為中心逆時針轉90
                    RotateTime++;
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                default:
                    break;
            }
        }
        StartCoroutine(standUp());
        RotateTime++;
    }
    IEnumerator rotatePlayer(float x, float y, float z)
    {
        for(int i = 0; i < 60; i++)
        {
            yield return new WaitForSeconds(0.01f);
            player.transform.Rotate(x/60f, y/60f, z/60f, Space.Self);
        }        
    }
    IEnumerator standUp()
    {yield return new WaitForSeconds(2f);
        player.GetComponent<Rigidbody>().isKinematic = true;
        print(player.transform.forward);
        
        float x = 0f;
        float y = 0f;
        float z = 0f;
        
        // 面朝地：物體Z軸為(0,-1,0)
        if (player.transform.forward.y > -1.1f && player.transform.forward.y < -0.9f){
            x = -90f;
        }
        // 面朝上：物體Z軸為(0,1,0)
        if (player.transform.forward.y < 1.1f && player.transform.forward.y > 0.9f){
           x = 90f;
        }
        // 右手朝下：物體X軸為(0,-1,0)
        if (player.transform.right.y > -1.1f && player.transform.right.y < -0.9f){
            z = 90f;
        }
        // 左手朝下：物體X軸為(0,1,0)
        if (player.transform.right.y < 1.1f && player.transform.right.y > 0.9f){
            z = -90f;
        }

        black.SetBool("start", true);
        yield return new WaitForSeconds(0.01f);
        black.SetBool("start", false);
        float time = 60f;
        for (float i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(0.01f);
            player.transform.Rotate(x / time, y / time, z / time, Space.Self);
        }

        player.GetComponent<Rigidbody>().isKinematic = false;
        // yield return new WaitForSeconds(2f);
        isRotating = false;        
    }
}
