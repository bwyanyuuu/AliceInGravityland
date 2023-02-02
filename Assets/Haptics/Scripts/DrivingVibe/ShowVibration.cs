using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowVibration : MonoBehaviour
{
    // from 0~100%
    public AbstractHeadband headband;
    public GameObject[] Motors;
    private int[] HeadbandState = new int[16];
    private Image[] MotorImages = new Image[16];

    private Color maxColor;

    void Start()
    {
        HeadbandState = headband.HeadbandIntensity;
        maxColor = Color.red;
        float diameter = 150.0f;
        for (int i = 0; i < 16; i++)
        {
            // HeadbandState[i] = (char)0;
            MotorImages[i] = Motors[i].GetComponent<Image>();
            Motors[i].GetComponent<RectTransform>().localPosition
                = new Vector2(diameter * Mathf.Cos(Mathf.PI / 2 - i * Mathf.PI / 8), diameter * Mathf.Sin(Mathf.PI / 2 - i * Mathf.PI / 8));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 16; i++)
        {
            MotorImages[i].color = Color.Lerp(Color.white, maxColor, (HeadbandState[i] / 100.0f));
        }
    }
}