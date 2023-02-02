using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Encoder : MonoBehaviour
{
    // private float PowerSource = 9.0f;
    // private float ForcePerVoltage = 1.6f;
    // private float MaximumForce = 2.3f;
    //public string calibrationFilePath = @"D:\calibrationResults\";
    //public string calibrationFileName = "0.txt";
    
    //public bool useWifi = true;

    [SerializeField]
    protected int[] VibratorIntensityWeight = new int[16];

    // get from calibration
    protected int maxIntensity;
    private int SystemInputMaxValue;
    public int minValue = 8;
    public int maxValue;
    public int globalMultiplier = 100;

    // public float updateInterval = 0.05f;
    public int FramesPerUpdate = 2;

    protected AbstractHeadband headband;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        headband = GetComponent<AbstractHeadband>();
        Iniitialize();
    }

    void Iniitialize()
    {
        //FileInfo calibrationFile = new FileInfo(calibrationFilePath + calibrationFileName);
        //StreamReader reader = calibrationFile.OpenText();
        for (int i = 0; i < 16; i++)
        {
            //VibratorIntensityWeight[i] = int.Parse(reader.ReadLine());
        }
        //SystemInputMaxValue = Mathf.FloorToInt(((MaximumForce / ForcePerVoltage) / PowerSource) * 256);
        SystemInputMaxValue = 40;
        //globalMultiplier = int.Parse(reader.ReadLine()); // Get from calibration
        maxValue = SystemInputMaxValue;
        //reader.Close();
        Debug.Log("Initialization finished.");
    }
}