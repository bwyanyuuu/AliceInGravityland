using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestPattern : Pattern {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            MultipleVibration(new List<int> { 0, 1, 2,14, 15 }, 200, 0.25f);
        }
    }
    private bool isBusy = false;
    public void SingleVibration(int index, int intensity, float duration) {
        if (isBusy) return;

        StartCoroutine(SingleVibrationCorutine(index, intensity, duration));
    }
    public void MultipleVibration(List<int> indice, int intensity, float duration) {
        if (isBusy) return;

        StartCoroutine(MultipleVibrationCorutine(indice, intensity, duration));
    }
    public void AllVibration(int intensity, float duration) {
        // intensity range: 0 ~ 100 (%)
        if (isBusy) return;
        StartCoroutine(MultipleVibrationCorutine(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, intensity, duration));
    }

    private IEnumerator SingleVibrationCorutine(int index, int intensity, float duration) {
        isBusy = true;
        // intensity range: 0 ~ 100 (%)
        SetIntensitiesToZero();
        if (index >= 0 && index < 16) {
            HeadbandIntensities[index] = intensity;
        }
        yield return new WaitForSeconds(duration);
        SetIntensitiesToZero();
        isBusy = false;
    }
    private IEnumerator MultipleVibrationCorutine(List<int> indice, int intensity, float duration) {
        isBusy = true;
        // intensity range: 0 ~ 100 (%)
        SetIntensitiesToZero();
        foreach (int index in indice) {
            if (index >= 0 && index < 16) {
                HeadbandIntensities[index] = intensity;
            }
        }
        yield return new WaitForSeconds(duration);
        SetIntensitiesToZero();
        isBusy = false;
    }
}

//[CustomEditor(typeof(TestPattern))]
//public class TestPatternBtn : Editor {
//    public override void OnInspectorGUI() {
//        base.OnInspectorGUI();
//        TestPattern motionScript = (TestPattern)target;

//        if (GUILayout.Button("Motion Sample")) {
//            motionScript.SingleVibration(0, 200, 0.5f);
//        }
//    }
//}