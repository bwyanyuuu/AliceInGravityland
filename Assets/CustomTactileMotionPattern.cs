using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomTactileMotionPattern : Pattern {
    public float ISOI = 0.05f;
    public float DurationOverlapByMotor = 4.0f;
    public float MotionIntervalByMotor = 5.0f;
    public int MotionIntensity = 40;

    public float _startAngle;
    public float _endAngle;
    public bool _isClockwise;

    private float duration;
    //private float motionInterval;
    //private float motionTimer = 0.0f;
    private float[] tactileMotionLifeSpans = new float[16];
    private int[] rawIntensity = new int[16];

    private void Start() {
        //motionTimer = 0.0f;
        //motionInterval = duration + MotionIntervalByMotor * ISOI;
        for (int i = 0; i < 16; i++) {
            tactileMotionLifeSpans[i] = -1.0f;
            rawIntensity[i] = 0;
        }
    }

    public void TactileMotionDebugger(bool isClockwise, float startAngle, float endAngle) {
        StartCoroutine(generateMotion(isClockwise, startAngle, endAngle, startAngle));
    }
    public void SingleTactileMotion(bool isClockwise, float startAngle, float endAngle) {
        StartCoroutine(generateMotion(isClockwise, startAngle, endAngle, 0.0f));
    }
    public void DoubleTactileMotionSample() {
        StartCoroutine(generateMotion(true, 0.0f, -180.0f, 0.0f));
        StartCoroutine(generateMotion(false, 0.0f, 180.0f, 0.0f));
    }

    private void FixedUpdate() {
        for (int i = 0; i < 16; i++) {
            tactileMotionLifeSpans[i] -= Time.fixedDeltaTime;
        }
        /*
        motionTimer -= Time.fixedDeltaTime;
        if (motionTimer < 0)
        {
            motionTimer = motionInterval;
            StartCoroutine(generateMotion(true, 0.0f, -180.0f, 0.0f));
            StartCoroutine(generateMotion(false, 0.0f, 180.0f, 0.0f));
        }
        */
        duration = DurationOverlapByMotor * ISOI;
        for (int i = 0; i < 16; i++) {
            if (tactileMotionLifeSpans[i] > 0) {
                HeadbandIntensities[i] = rawIntensity[i];
            }
            else {
                HeadbandIntensities[i] = 0;
            }
        }
    }

    private IEnumerator generateMotion(bool isClockwise, float startAngle, float endAngle, float currentAngle) {
        float angleSpeed = 22.5f / ISOI;
        float angleStep = angleSpeed * Time.fixedDeltaTime;
        float nextAngle;
        bool activateThisIndex;

        // Very ugly but necessary code for marking the correct break point
        if (endAngle == -180.0f) { endAngle = 180.0f; }
        if (Math.Abs(currentAngle - endAngle) <= angleStep) { yield break; }
        else if (endAngle == 180.0f) {
            if (Math.Abs(Math.Abs(currentAngle) - endAngle) < 1) { yield break; }
        }

        if (isClockwise) {
            nextAngle = currentAngle - angleStep;
            if (nextAngle < -180.0f) { nextAngle += 360.0f; }
        }
        else {
            nextAngle = currentAngle + angleStep;
            if (nextAngle > 180.0f) { nextAngle -= 360.0f; }
        }

        for (int i = 0; i < 16; i++) {
            activateThisIndex = false;
            if (isClockwise) {
                if (currentAngle > AngleOfEachVibrator[i] && nextAngle <= AngleOfEachVibrator[i]) {
                    activateThisIndex = true;
                }
                else if (i == 8 && currentAngle < 0 && nextAngle >= 0) {
                    activateThisIndex = true;
                }
            }
            else {
                if (currentAngle < AngleOfEachVibrator[i] && nextAngle >= AngleOfEachVibrator[i]) {
                    activateThisIndex = true;
                }
                else if (i == 8 && currentAngle >= 0 && nextAngle < 0) {
                    activateThisIndex = true;
                }
            }

            if (activateThisIndex) {
                tactileMotionLifeSpans[i] = duration;
                rawIntensity[i] = MotionIntensity;
            }
        }

        yield return new WaitForFixedUpdate();
        StartCoroutine(generateMotion(isClockwise, startAngle, endAngle, nextAngle));
        yield break;
    }
}

[CustomEditor(typeof(CustomTactileMotionPattern))]
public class CustomTactileMotionPatternBtn : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        CustomTactileMotionPattern motionScript = (CustomTactileMotionPattern)target;

        if (GUILayout.Button("Tactile Motion Sample")) {
            //motionScript.DoubleTactileMotionSample();
            motionScript.TactileMotionDebugger(motionScript._isClockwise, motionScript._startAngle, motionScript._endAngle);
        }
    }
}