using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractHeadband : MonoBehaviour
{
    // Refactored version of virtual headband
    // From 0~100 intensity
    public int[] HeadbandIntensity = new int[16];
    public List<Pattern> Patterns;

    private void Start()
    {
        //Patterns.Add(GetComponent<TestPattern>());

        for (int i = 0; i < 16; i++)
        {
            HeadbandIntensity[i] = 0;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 16; i++)
        {
            HeadbandIntensity[i] = 0;
        }
        foreach (Pattern pattern in Patterns)
        {
            for (int i = 0; i < 16; i++)
            {
                HeadbandIntensity[i] += pattern.HeadbandIntensities[i];
            }
        }
        for (int i = 0; i < 16; i++)
        {
            HeadbandIntensity[i] = Mathf.Max(0, Mathf.Min(HeadbandIntensity[i], 100));
        }
    }
}