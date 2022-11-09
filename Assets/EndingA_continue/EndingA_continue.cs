using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingA_continue : MonoBehaviour
{
    public GameObject ed_control;
    public GameObject boat_captain_0;
    public GameObject boat_captain_1;
    public GameObject boat_captain_2;
    public GameObject OVR_camera;
    public GameObject WhirlpoolScene;
    public GameObject final;
    public GameObject movie;
    public GameObject movie_environment;
    public AudioManager am;
    static Caption caption;
    // Start is called before the first frame update
    void Start()
    {
        caption = ed_control.GetComponent<Caption>();
        Invoke("talk0", 19);
        Invoke("captain_ani_1", 6);
        Invoke("captain_ani_2", 15);
        
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }*/

    void talk0()//這是...我回來了？
    {
        caption.Play(0);
        Invoke("talk1", 6);
    }
    void talk1()// …欸！？船長你難道就是…(驚訝)
    {
        caption.Play(1);
    }

    void captain_ani_1()
    {
        boat_captain_0.SetActive(false);
        boat_captain_1.SetActive(true);
    }

    void captain_ani_2()
    {
        boat_captain_1.SetActive(false);
        boat_captain_2.SetActive(true);
        Invoke("fadein", 12);
    }
    void fadein()
    {
        am.Stop();
        movie.SetActive(true);
        OVR_camera.transform.parent = null;
        OVR_camera.transform.position = new Vector3(-0.18f,0.0f,0.0f);
        OVR_camera.transform.eulerAngles = new Vector3(0.0f,90.0f,0.0f);
        WhirlpoolScene.SetActive(false);
        movie_environment.SetActive(true); 
        final.SetActive(true);
    }
}
