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
    public int RotateCount=0;   // RotateCount: 刪去RoomB後用來計算選轉了幾次
    public bool ChandelierFloor=false;
    public AkilliMum.SRP.Mirror.CameraShade cameraShade;
    public GameObject mirror_reflect;
    private AkilliMum.SRP.Mirror.FollowVector followVector;
    public GameObject[] vibes;
    public GameObject hapticManager;

    public GameObject[] WallColliders;    // WallColliders: 刪去RoomB後把wall collider關掉
    public GameObject[] WallBlack;        // WallBlack: 刪去RoomB後把wall black關掉

    private CustomTactileMotionPattern tactilePattern;
    private TestPattern testPattern;

    private bool isRotating = false;
    private Vector3 rot;
    private bool wait = true;
    private int idx;
    
    void Start()
    {
        rot = player.transform.localEulerAngles;
        tactilePattern = hapticManager.GetComponent<CustomTactileMotionPattern>();
        testPattern = hapticManager.GetComponent<TestPattern>();
    }
    void Update() {
        if (!isRotating) // lock all
        {
            player.transform.localEulerAngles = rot;
        }
        // else print(player.transform.localEulerAngles);

        ////////////////////////
        // 要改撞玻璃的次數這邊改完還要去PlayController.cs(掛在camera上)->OnCollisionEnter改撞擊次數->mirrorbreak1.SetActive修改
        // if (RotateTime == 1)
        // {
        //     mirrorbreak1.SetActive(true);
        //     mirrorglass.SetActive(false);
        // }
        // else if (RotateTime == 2)
        // {
        //     //mirrorbreak2.SetActive(true);
        //     //mirrorbreak1.SetActive(false);
        //     mirrorCollider.SetActive(true);
        //     RotateTime++;
        // }
        ////////////////////////

        // 去掉RoomB後玩家轉10次就把房間牆壁和地板collider全部拔掉->掉下去切scene
        if (RotateCount == 3)
        {
            BreakRoom();
            RotateCount++;
        }





        //else if (RotateTime == 3)
        //{
        //    mirrorbreak3.SetActive(true);
        //    mirrorbreak2.SetActive(false);
        //    //Chandelier.GetComponent<Rigidbody>().useGravity = true;
        //    //Chandelier.GetComponent<Collider>().enabled = true;
        //    mirrorCollider.SetActive(true);
        //    RotateTime++;
        //}
        // else if (RotateTime == 5)
        // {
        //     // Rigidbody ChandelierRigidBody = Chandelier.AddComponent<Rigidbody>();
        //     // ChandelierRigidBody.useGravity = true;
        //     mirrorbreak5.SetActive(true);
        //     mirrorbreak4.SetActive(false);
            
        // }

		
	}
    public void BreakRoom()
    {
        for (int i = 0; i < WallColliders.Length; i++) {
            WallColliders[i].GetComponent<Collider>().enabled = false;
        }
        for (int i = 0; i < WallBlack.Length; i++) {
            WallBlack[i].SetActive(false);
        }
        
    }


    public void rotate(int i, Vector3 src)
    {
        //print("rotate "+src);
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
                    //RotateTime++;
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
        // 往上的時候空中轉90度
        //Quaternion final = new Quaternion(player.transform.rotation.x + x, player.transform.rotation.y + y, player.transform.rotation.z + z, 1f);
        player.GetComponent<Collider>().enabled = false;
        Vector3 movePos = new Vector3(1f/60f, 0f, 0f);
        for (int i = 0; i < 60; i++)
        {
            yield return new WaitForSeconds(0.01f);
            // player.transform.rotation = new Quaternion(player.transform.rotation.x+x / 60f, player.transform.rotation.y+y / 60f, player.transform.rotation.z+z / 60f, 1f);
            player.transform.Rotate(x/60f, y/60f, z/60f, Space.Self);
            if(i == 20) player.GetComponent<Collider>().enabled = true;
            //player.transform.position += movePos;
        }  
        // for(int i = 0; i < 60; i++)
        // {
        //     yield return new WaitForSeconds(0.01f);
        //     player.transform.Rotate(x/60f, y/60f, z/60f, Space.Self);
        // }        
    }
    IEnumerator standUp()
    {
        //if (mirror.transform.up.y == 1.0f) {
        //    RotateTime++;
        //}
        // 往下落的過程
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        // 落地有風，判斷風的方向 (不包括往上)
        // 面朝地：物體Z軸為(0,-1,0)
        // print(camera.transform.forward.y + " " + camera.transform.right.y);
        if (camera.transform.forward.y > -1.5f && camera.transform.forward.y < -0.5f) {
            tactilePattern.TactileMotionDebugger(true, 0f, tactilePattern.getEndAngle(0f));
            tactilePattern.TactileMotionDebugger(false, 0f, tactilePattern.getEndAngle(0f));
            // print("a");
        }
        //面朝上：物體Z軸為(0, 1, 0)
        else if (camera.transform.forward.y < 1.5f && camera.transform.forward.y > 0.5f) {
            tactilePattern.TactileMotionDebugger(true, 180f, tactilePattern.getEndAngle(180f));
            tactilePattern.TactileMotionDebugger(false, 180f, tactilePattern.getEndAngle(180f));
            // print("b");
        }
        //右手朝下：物體X軸為(0, -1, 0)
        else if (camera.transform.right.y > -1.5f && camera.transform.right.y < -0.5f) {
            tactilePattern.TactileMotionDebugger(true, -90f, tactilePattern.getEndAngle(-90f));
            tactilePattern.TactileMotionDebugger(false, -90f, tactilePattern.getEndAngle(-90f));
            // print("c");
        }
        //左手朝下：物體X軸為(0, 1, 0)
        else if (camera.transform.right.y < 1.5f && camera.transform.right.y > 0.5f) {
            tactilePattern.TactileMotionDebugger(true, 90f, tactilePattern.getEndAngle(90f));
            tactilePattern.TactileMotionDebugger(false, 90f, tactilePattern.getEndAngle(90f));
            // print("d");
        }
        else{
            testPattern.AllVibration(40, 0.75f);
        }
        


        // 換鏡子反射
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
            mirror_reflect.transform.position = new Vector3(0.119999997f, 6.44999981f, -2.09f);
        }
        else if (transform.up.z > -1.1f && transform.up.z < -0.9f)
        {
            followVector = AkilliMum.SRP.Mirror.FollowVector.RedX; // Vector3(0.119999997,4.3499999,1.97000003)
            mirror_reflect.transform.position = new Vector3(0.12f, 4.35f, 1.97f);
        }
        cameraShade.UpVector = followVector;

        

        // 打開震動碰撞
        for (int i = 0; i < vibes.Length; i++) {
            vibes[i].SetActive(true);
        }


        
        // 開始掉落
        //yield return new WaitForSeconds(3f); 
        yield return new WaitForSeconds(0.7f);
        //撞到鏡子RotateTime++
        //if (mirror.transform.up.y == 1.0f)
        //{
        //    RotateTime++;
        //}
        //// 計算轉了幾次(撞到鏡子除外)
        //if (mirror.transform.up.y != 1.0f)
        //{
        //    RotateCount++;
        //}
        RotateCount++;
        yield return new WaitForSeconds(2.3f);
        // 掉落完成



        // 關掉震動碰撞
        for (int i = 0; i < vibes.Length; i++) {
            vibes[i].SetActive(false);
        }

        // 進行設定
        player.GetComponent<Rigidbody>().isKinematic = true;
        rot = player.transform.localEulerAngles;

        

        // 判斷站起來的方向
        float forward = camera.transform.forward.y;
        float right = camera.transform.right.y;
        Vector3 pf = player.transform.forward;
        Vector3 pr = player.transform.right;
        float x = 0f;
        float y = 0f;// -rot.y;
        float z = 0f;
       
        
        // 面朝地：物體Z軸為(0,-1,0)
        if (player.transform.forward.y > -1.2f && player.transform.forward.y < -0.8f){
            x = -90f;
            //print("a");
        }
        // 面朝上：物體Z軸為(0,1,0)
        if (player.transform.forward.y < 1.2f && player.transform.forward.y > 0.8f){
           x = 90f;
            //print("b");
        }
        // 右手朝下：物體X軸為(0,-1,0)
        if (player.transform.right.y > -1.2f && player.transform.right.y < -0.8f){
            z = 90f;
            //print("c");
        }
        // 左手朝下：物體X軸為(0,1,0)
        if (player.transform.right.y < 1.2f && player.transform.right.y > 0.8f){
            z = -90f;
            //print("d");
        }

        // 站起來
        black.SetTrigger("wink");
        float time = 60f;
        for (float i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(0.01f);
            player.transform.Rotate(x / time, y / time, z / time, Space.Self);
        }

        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rot = player.transform.localEulerAngles;
        isRotating = false;  
    }
    public void up()
    {
        this.transform.RotateAround(center.position, Vector3.forward, 180);
    }
}
