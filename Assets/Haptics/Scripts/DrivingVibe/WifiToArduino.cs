using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Net;
using System.Net.Sockets;

public class WifiToArduino : MonoBehaviour
{
    private int motorCount = 16;
    private byte[] setZeroBytes;
    // public static string deviceIP = "192.168.50.20";
    public string deviceIP;
    public static int devicePort = 80;
    private Socket socket;
    public bool arduinoPaused = true;
    public bool showString = false;

    void Start()
    {
        arduinoPaused = true;
        setZeroBytes = new byte[motorCount];
        for (int i = 0; i < motorCount; i++)
        {
            setZeroBytes[i] = System.Convert.ToByte((char)0);
        }
        StartConnection();
    }
    public void startArduino()
    {
        arduinoPaused = false;
    }
    public void PauseArduino()
    {
        arduinoPaused = true;
        setAllToZero();
    }
    public void writeToArduinoByte(byte[] input)
    {
        if (showString && !arduinoPaused)
        {
            Debug.Log("Send to arduino: " + input[0].ToString() + " "
                + input[1].ToString() + " "
                + input[2].ToString() + " "
                + input[3].ToString() + " "
                + input[4].ToString() + " "
                + input[5].ToString() + " "
                + input[6].ToString() + " "
                + input[7].ToString() + " "
                + input[8].ToString() + " "
                + input[9].ToString() + " "
                + input[10].ToString() + " "
                + input[11].ToString() + " "
                + input[12].ToString() + " "
                + input[13].ToString() + " "
                + input[14].ToString() + " "
                + input[15].ToString());
        }
        if (socket.Connected && !arduinoPaused)
        {
            // socket.Send(input);
            System.ArraySegment<byte> data = new System.ArraySegment<byte>(input);
            socket.SendAsync(data, SocketFlags.None);
        }
    }
    public void StartConnection()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Debug.Log("Establishing Connection to " + deviceIP);
        //socket.Connect(deviceIP, devicePort);

        IAsyncResult result = socket.BeginConnect(deviceIP, devicePort, null, null);

        bool success = result.AsyncWaitHandle.WaitOne(3000, true);

        if (socket.Connected)
        {
            Debug.Log("Connection established!");
            socket.NoDelay = true;
            arduinoPaused = false;
        }
        else
        {
            Debug.Log("Connection timeout!");
            socket.Close();
        }
    }
    public void ReOpen()
    {
        if (socket.Connected)
        {
            Debug.Log("Close current connection...");
            socket.Close();
            arduinoPaused = true;
        }
        else
        {
            Debug.Log("No connection right now. Straight connecting...");
        }
        StartConnection();
    }
    public void setAllToZero()
    {
        Debug.Log("Set all intensities to zero");
        for (int i = 0; i < motorCount; i++)
        {
            if (socket.Connected)
            {
                socket.Send(setZeroBytes);
            }
        }
    }
    private void OnApplicationQuit()
    {
        if (socket.Connected)
        {
            setAllToZero();
            Debug.Log("Close connection.");
            socket.Close();
        }
    }
}
[CustomEditor(typeof(WifiToArduino))]
public class ReconnectBtn : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        WifiToArduino wifiToArduino = (WifiToArduino)target;

        if (GUILayout.Button("Reconnect"))
        {
            wifiToArduino.ReOpen();
        }
    }
}