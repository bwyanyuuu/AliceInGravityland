using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDoorController : MonoBehaviour
{
    private bool isTouching = false;
    private Vector3 doorposition = new Vector3(0.0f, 0.008f, -0.003f);
    private float doorAngle_x = 0.0f;
    private float doorAngle_z = 0.0f;
    private float doorAngle_y = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        doorposition = gameObject.transform.localPosition;
        doorAngle_x = gameObject.transform.localEulerAngles.x;
        doorAngle_z = gameObject.transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            gameObject.transform.localPosition = doorposition;
            doorAngle_y = 180 - (gameObject.transform.localEulerAngles.y % 360);
            print(gameObject.transform.localEulerAngles.y + " " + doorAngle_y);

            //if (doorAngle_y <= 0f) doorAngle_y = 0f;
            //else if (doorAngle_y >= 90f) doorAngle_y = 90f;
            
            gameObject.transform.localEulerAngles = new Vector3(doorAngle_x, doorAngle_y, doorAngle_z);
            print(gameObject.transform.localEulerAngles.y+" "+doorAngle_y);
        }
        

    }
    public void touch(bool status)
    {
        isTouching = status;
        if (status)
        {
            doorposition = gameObject.transform.localPosition;
            doorAngle_x = gameObject.transform.localEulerAngles.x;
            doorAngle_z = gameObject.transform.localEulerAngles.z;
            
        }
    }
}
