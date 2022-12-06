using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPocketClockController : MonoBehaviour
{
    // public GameObject breakpocketclock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pickUp(GameObject breakpocketclock)
    {
        // put the card onto the hand        
        StartCoroutine(disappear(breakpocketclock));
        breakpocketclock.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();   
    }

    IEnumerator disappear(GameObject breakpocketclock)
    {
        yield return new WaitForSeconds(2f);
        breakpocketclock.SetActive(false);
    }
}
