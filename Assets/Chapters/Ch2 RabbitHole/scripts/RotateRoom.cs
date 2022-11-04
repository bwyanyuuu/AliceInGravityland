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
	//转动速度
	public float rotationSpeed=10;
	void Update() {
		//跟随center转圈圈
        if (Input.GetKeyDown(KeyCode.W)){
            this.transform.RotateAround(center.position, Vector3.forward, 180);
            //player.transform.Rotate(180f, 90f, 0f, Space.Self);

        }
		if (Input.GetKeyDown(KeyCode.A)){
            this.transform.RotateAround(center.position, Vector3.forward, 90);
        }
		if (Input.GetKeyDown(KeyCode.D)){
            this.transform.RotateAround(center.position, Vector3.forward, 270);
        }
        if (Input.GetKeyDown(KeyCode.X)){
            this.transform.RotateAround(center.position, Vector3.left, 90);
        }
        if (Input.GetKeyDown(KeyCode.C)){
            this.transform.RotateAround(center.position, Vector3.left, -90);
        }
		
	}
    public void rotate(int i)
    {
        switch(i)
        {
            case 0: // up
                this.transform.RotateAround(center.position, Vector3.forward, 180);
                //player.transform.Rotate(180f, 0f, 0f, Space.Self);
                StartCoroutine(rotatePlayer(90f, 0f, 0f));
                break;
            case 1: // front
                //this.transform.RotateAround(center.position, Vector3.forward, 90);
                break;
            case 2: // back
                //this.transform.RotateAround(center.position, Vector3.forward, 180);
                break;
            case 3: // left
                this.transform.RotateAround(center.position, Vector3.forward, 90);
                break;
            case 4: // right
                this.transform.RotateAround(center.position, Vector3.forward, 270);
                break;
            default:
                break;
        }
    }
    IEnumerator rotatePlayer(float x, float y, float z)
    {
        for(int i = 0; i < 60; i++)
        {
            yield return new WaitForSeconds(0.01f);
            player.transform.Rotate(x/60f, y/60f, z/60f, Space.Self);
        }
        
    }
}
