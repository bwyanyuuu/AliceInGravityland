using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    public Transform center;
    public GameObject player;
    public GameObject camera;
    public Animator black;
    public GameObject mirrorCollider;
    public GameObject Chandelier;
    public GameObject pokerTravel;
    public GameObject mirror;
    public GameObject mirrorglass;
    public GameObject mirrorbreak1;
    public GameObject mirrorbreak2;
    public GameObject mirrorbreak3;
    public GameObject mirrorbreak4;
    public GameObject mirrorbreak5;
    public Transform[] anchors; // 0: +x, 1: -x, 2: +z, 3: -z, 4 +y
    public float rotationSpeed=10;
    public int RotateTime=0;
    public bool ChandelierFloor=false;

    private bool isRotating = false;
    private Vector3 rot;
    private bool wait = true;
    
    void Start()
    {
        rot = player.transform.localEulerAngles;
    }
    void Update() {
        if (!isRotating) // lock all
        {
            player.transform.localEulerAngles = rot;
        }
        // else print(player.transform.localEulerAngles);
        if (RotateTime == 1)
        {
            mirrorbreak1.SetActive(true);
            mirrorglass.SetActive(false);
        }
        else if (RotateTime == 2)
        {
            mirrorbreak2.SetActive(true);
            mirrorbreak1.SetActive(false);
        }
        else if (RotateTime == 3)
        {
            mirrorbreak3.SetActive(true);
            mirrorbreak2.SetActive(false);  
        }
        else if (RotateTime == 4)
        {
            mirrorbreak4.SetActive(true);
            mirrorbreak3.SetActive(false);    
        }
        else if (RotateTime >= 5)
        {
            // Rigidbody ChandelierRigidBody = Chandelier.AddComponent<Rigidbody>();
            // ChandelierRigidBody.useGravity = true;
            mirrorbreak5.SetActive(true);
            mirrorbreak4.SetActive(false);
            Chandelier.GetComponent<Rigidbody>().useGravity = true;
            Chandelier.GetComponent<Collider>().enabled = true;
            mirrorCollider.SetActive(true);
        }

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
    public void rotate(int i, Vector3 src)
    {
        if (isRotating) return;
        else isRotating = true;
        float phase = camera.transform.eulerAngles.y;
        // 面向+z軸
        if (phase % 360 > 315.0f || phase % 360 < 45.0f)
        {
            switch (i)
            {
                case 0: // up
                    activateAnchor(new Vector3(0f, 1f, 0f), src);
                    StartCoroutine(rotateWait(0, Vector3.forward));
                    RotateTime++;
                    break;
                case 1: // left
                    activateAnchor(new Vector3(-1f, 0f, 0f), src);
                    StartCoroutine(rotateWait(1, Vector3.forward));
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 2: // right
                    activateAnchor(new Vector3(1f, 0f, 0f), src);
                    StartCoroutine(rotateWait(2, Vector3.forward));
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
                    activateAnchor(new Vector3(0f, 1f, 0f), src);
                    StartCoroutine(rotateWait(0, Vector3.forward));
                    break;
                case 1: // left
                    activateAnchor(new Vector3(1f, 0f, 0f), src);
                    StartCoroutine(rotateWait(2, Vector3.forward));
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 2: // right
                    activateAnchor(new Vector3(-1f, 0f, 0f), src);
                    StartCoroutine(rotateWait(1, Vector3.forward));
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
                    activateAnchor(new Vector3(0f, 1f, 0f), src);
                    StartCoroutine(rotateWait(0, Vector3.forward));
                    break;
                case 1: // left
                    activateAnchor(new Vector3(0f, 0f, 1f), src);
                    StartCoroutine(rotateWait(1, Vector3.right));
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 2: // right
                    activateAnchor(new Vector3(0f, 0f, -1f), src);
                    StartCoroutine(rotateWait(2, Vector3.right));
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
                    activateAnchor(new Vector3(0f, 1f, 0f), src);
                    StartCoroutine(rotateWait(0, Vector3.forward));
                    break;
                case 1: // left
                    activateAnchor(new Vector3(0f, 0f, -1f), src);
                    StartCoroutine(rotateWait(2, Vector3.right));
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                case 2: // right
                    activateAnchor(new Vector3(0f, 0f, 1f), src);
                    StartCoroutine(rotateWait(1, Vector3.right));
                    if (ChandelierFloor) ChandelierFloor = false;
                    break;
                default:
                    break;
            }
        }
    }
    private void activateAnchor(Vector3 orient, Vector3 src)
    {
        if (src.x == 0 && src.y == 0 && src.z == 0)
        {
            wait = false;
            return;
        }
        Vector3 dst = new Vector3(0f, 0f, 0f);
        float target = -200f;
        for(int i = 0; i < 6; i++)
        {
            var c = Vector3.Dot(anchors[i].position, orient);
            if(c > target)
            {
                target = c;
                dst = anchors[i].position;
            }
        }
        pokerTravel.SetActive(true);
        pokerTravel.GetComponent<PokerTravel>().move(dst, dst);
    }
    IEnumerator rotateWait(int mode, Vector3 dir)
    {
        if (wait) yield return new WaitForSeconds(2f);
        else wait = true;
        pokerTravel.SetActive(false);
        switch (mode)
        {
            case 0:
                transform.RotateAround(center.position, dir, 180);
                StartCoroutine(rotatePlayer(90f, 0f, 0f));
                break;
            case 1:
                transform.RotateAround(center.position, dir, 90);
                break;
            case 2:
                transform.RotateAround(center.position, dir, -90);
                break;
            default:
                break;
        }
        if (mirror.transform.up.y == 1.0f)
        {
            RotateTime++;
        }
        StartCoroutine(standUp());
    }
    IEnumerator rotatePlayer(float x, float y, float z)
    {
        //Quaternion final = new Quaternion(player.transform.rotation.x + x, player.transform.rotation.y + y, player.transform.rotation.z + z, 1f);
        for (int i = 0; i < 60; i++)
        {
            // player.GetComponent<Rigidbody>().isKinematic = true;
            // player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            yield return new WaitForSeconds(0.01f);
            // player.transform.rotation = new Quaternion(player.transform.rotation.x+x / 60f, player.transform.rotation.y+y / 60f, player.transform.rotation.z+z / 60f, 1f);
            player.transform.Rotate(x/60f, y/60f, z/60f, Space.Self);
            // player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            // player.GetComponent<Rigidbody>().isKinematic = false;
        }  
        // for(int i = 0; i < 60; i++)
        // {
        //     yield return new WaitForSeconds(0.01f);
        //     player.transform.Rotate(x/60f, y/60f, z/60f, Space.Self);
        // }        
    }
    IEnumerator standUp()
    {
       
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(3f);
        player.GetComponent<Rigidbody>().isKinematic = true;
        print(camera.transform.forward+" "+camera.transform.right);
        print(player.transform.forward+" "+player.transform.right);
        float forward = camera.transform.forward.y;
        float right = camera.transform.right.y;
        Vector3 pf = player.transform.forward;
        Vector3 pr = player.transform.right;
        // print(rot);
        // if (rot.y > 180) rot.y -= 360f;
        float x = 0f;
        float y = 0f;// -rot.y;
        float z = 0f;
        
        // print(rot.y);
        
        // 面朝地：物體Z軸為(0,-1,0) == -1f
        // if()
        // 面朝地：物體Z軸為(0,-1,0)
        if (player.transform.forward.y > -1.2f && player.transform.forward.y < -0.8f){
            x = -90f;
            print("a");
        }
        // 面朝上：物體Z軸為(0,1,0)
        if (player.transform.forward.y < 1.2f && player.transform.forward.y > 0.8f){
           x = 90f;
            print("b");
        }
        // 右手朝下：物體X軸為(0,-1,0)
        if (player.transform.right.y > -1.2f && player.transform.right.y < -0.8f){
            z = 90f;
            print("c");
        }
        // 左手朝下：物體X軸為(0,1,0)
        if (player.transform.right.y < 1.2f && player.transform.right.y > 0.8f){
            z = -90f;
            print("d");
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
        // for (float i = 1; i <= time; i++)
        // {
        //     yield return new WaitForSeconds(0.01f);
        //     player.transform.localEulerAngles = new Vector3 (rot.x + x / time * i, rot.y, rot.z + z / time * i);
        //     //print("after " + player.transform.localEulerAngles);

        // }
        print("new " + new Vector3(rot.x + x, rot.y + y, rot.z + z) + " " + x + " " + y + " " + z);
        
        print("after " + player.transform.localEulerAngles);print("ROTATE " + x + " " + y + " " + z);
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
        
        rot = player.transform.localEulerAngles;print("set "+rot);
        // yield return new WaitForSeconds(2f);
        isRotating = false;  
    }
    public void up()
    {
        this.transform.RotateAround(center.position, Vector3.forward, 180);
    }
}
