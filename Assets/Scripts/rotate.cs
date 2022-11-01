using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
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
	//转动速度
	public float rotationSpeed=10;
	void Update() {
		//跟随center转圈圈
        if (Input.GetKeyDown(KeyCode.W)){
            this.transform.RotateAround(center.position, Vector3.forward, 180);
        }
		if (Input.GetKeyDown(KeyCode.A)){
            this.transform.RotateAround(center.position, Vector3.forward, 90);
        }
		if (Input.GetKeyDown(KeyCode.D)){
            this.transform.RotateAround(center.position, Vector3.forward, 270);
        }
		
	}

}
