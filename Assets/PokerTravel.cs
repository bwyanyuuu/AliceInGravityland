using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerTravel : MonoBehaviour
{
    public void move(Vector3 src, Vector3 dst){
        transform.position = src;
        dst = (dst - src) / 60;
    }
    IEnumerator trans(Vector3 step){
        for(int i = 0; i < 60; i++){
            transform.position += step;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
