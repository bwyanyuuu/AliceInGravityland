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
    //public GameObject Chandelier;
    public GameObject pokerTravel;
    public GameObject mirror;
    public GameObject mirrorglass;
    public GameObject mirrorbreak1;
    public GameObject mirrorbreak2;
    public GameObject mirrorbreak3;
    // public GameObject mirrorbreak4;
    // public GameObject mirrorbreak5;
    public Transform[] anchors; // 0: +x, 1: -x, 2: +z, 3: -z, 4 +y
    public float rotationSpeed=10;
    public int RotateTime=0;
    public bool ChandelierFloor=false;
    public AkilliMum.SRP.Mirror.CameraShade cameraShade;
    public GameObject mirror_reflect;
    private AkilliMum.SRP.Mirror.FollowVector followVector;

    private bool isRotating = false;
    private Vector3 rot;
    private bool wait = true;
    private int idx;
    
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
            //Chandelier.GetComponent<Rigidbody>().useGravity = true;
            //Chandelier.GetComponent<Collider>().enabled = true;
            mirrorCollider.SetActive(true);
            RotateTime++;
        }
        // else if (RotateTime == 5)
        // {
        //     // Rigidbody ChandelierRigidBody = Chandelier.AddComponent<Rigidbody>();
        //     // ChandelierRigidBody.useGravity = true;
        //     mirrorbreak5.SetActive(true);
        //     mirrorbreak4.SetActive(false);
            
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
    public void rotate(int i, Vector3 src)
    {
        print("rotate "+src);
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
                idx = i;
            }
        }
        
        //print(player.transform.up);
        
        // pokerTravel.SetActive(true);
        pokerTravel.GetComponent<PokerTravel>().move(src, dst);
    }
    IEnumerator rotateWait(int mode, Vector3 dir)
    {
        if (wait) yield return new WaitForSeconds(3f);
        wait = true;
        // pokerTravel.SetActive(false);
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
        print("up " + transform.up);
        print("right " + transform.right);
        mirror_reflect.transform.position = new Vector3(0.12f, 2.13f, 1.97f);
        if (idx == 5)
        {
            followVector = AkilliMum.SRP.Mirror.FollowVector.GreenY;
            mirror_reflect.transform.position = new Vector3(0.12f, 2.13f, 1.97f);

        }
        else if (idx == 4)
        {
            followVector = AkilliMum.SRP.Mirror.FollowVector.GreenY_Negative;
            mirror_reflect.transform.position = new Vector3(0.12f, 6.1f, 1.97f);//Vector3(0.119999997,6.0999999,1.97000003)
        }
        else if (transform.up.x < 1.1f && transform.up.x > 0.9f)
        {
            followVector = AkilliMum.SRP.Mirror.FollowVector.BlueZ_Negative;//Vector3(0.119999997,145,1.97000003)
            mirror_reflect.transform.position = new Vector3(0.12f, 145f, 1.97f);
        }
        else if (transform.up.x > -1.1f && transform.up.x < -0.9f)
        {
            followVector = AkilliMum.SRP.Mirror.FollowVector.BlueZ;//Vector3(0.119999997,-123.559998,1.97000003)
            mirror_reflect.transform.position = new Vector3(0.12f, -123.56f, 1.97f);
        }
        else if (transform.up.z < 1.1f && transform.up.z > 0.9f)//Vector3(0.119999997,6.44999981,-2.08999991)
        {
            followVector = AkilliMum.SRP.Mirror.FollowVector.RedX_Negative;
            mirror_reflect.transform.position = new Vector3(0.119999997f, 6.44999981f, 0.230000004f);
        }
        else if (transform.up.z > -1.1f && transform.up.z < -0.9f)
        {
            followVector = AkilliMum.SRP.Mirror.FollowVector.RedX; // Vector3(0.119999997,4.3499999,1.97000003)
            mirror_reflect.transform.position = new Vector3(0.12f, 4.35f, 1.97f);
        }
            //Vector3(0.119999997, 6.44999981, 0.230000004)
            print(followVector);
        cameraShade.UpVector = followVector;
        yield return new WaitForSeconds(3f);
        if (mirror.transform.up.y == 1.0f)
        {
            RotateTime++;
        }
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

        black.SetTrigger("wink");
        float time = 60f;
        for (float i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(0.01f);
            player.transform.Rotate(x / time, y / time, z / time, Space.Self);
        }
        print("new " + new Vector3(rot.x + x, rot.y + y, rot.z + z) + " " + x + " " + y + " " + z);
        
        print("after " + player.transform.localEulerAngles);print("ROTATE " + x + " " + y + " " + z);
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        print("up "+transform.up);
        print("right " + transform.right);

        
        rot = player.transform.localEulerAngles;print("set "+rot);
        // yield return new WaitForSeconds(2f);
        isRotating = false;  
    }
    public void up()
    {
        this.transform.RotateAround(center.position, Vector3.forward, 180);
    }
}
