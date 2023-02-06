using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerTravel : MonoBehaviour
{
    private GameObject p;
    void Start(){
        p = gameObject.transform.GetChild(0).gameObject;
    }
    public void move(Vector3 src, Vector3 dst){
        //print("dstsrc " + dst+" "+src);

        p.transform.position = src;
        p.SetActive(true);
        StartCoroutine(trans((dst - src) / 100));
    }
    IEnumerator trans(Vector3 step){
        //print("step " + step);
        for(int i = 0; i < 100; i++){
            p.transform.position += step;
            yield return new WaitForSeconds(0.03f);
        }
        p.SetActive(false);
    }
}
