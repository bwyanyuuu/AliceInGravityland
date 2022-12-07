using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockShine : MonoBehaviour
{
    public GameObject clock;
    public GameObject ArrowHour;
    public GameObject ArrowMin;
    public GameObject ArrowSec;
    public GameObject clockturn;

    public Material clockmetalMaterial;
    public Material clockwhiteMaterial;
    public Material clockblackMaterial;
    public Material knobMaterial;
    public Material clockmetalGlowMaterial;
    public Material clockwhiteGlowMaterial;
    public Material clockblackGlowMaterial;
    public Material knobGlowMaterial;

    // private bool Bscene = false;
    // private bool FirstTake = false;
    // private bool TurnShine = false;
    //private GameMaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
     
    }

    public void FirstTake()
    {
        clock.GetComponent<MeshRenderer>().materials[0] = clockmetalMaterial;
        clock.GetComponent<MeshRenderer>().materials[1] = clockwhiteMaterial;
        ArrowHour.GetComponent<MeshRenderer>().material = clockblackMaterial;
        ArrowMin.GetComponent<MeshRenderer>().material = clockblackMaterial;
        ArrowSec.GetComponent<MeshRenderer>().material = clockblackMaterial;
    }
    public void TurnShineClose()
    {
        clockturn.GetComponent<MeshRenderer>().material = knobMaterial;
    }
}
