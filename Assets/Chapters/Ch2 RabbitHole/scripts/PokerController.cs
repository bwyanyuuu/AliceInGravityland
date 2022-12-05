using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerController : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject cards;
    public Vector3[] pos;
    public Quaternion[] rot;
    
    // private GameMaster gameMaster;   
    private bool isTutorial = false;
    private RotateRoom rotateRoom;
    // private List<int> cardOwned = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        // gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        rotateRoom = gameObject.GetComponent<RotateRoom>();
        //for(int i = 0; i < 5; i++)
        //{
        //    print(cards.transform.GetChild(i).transform.localPosition);
        //    print(cards.transform.GetChild(i).transform.localRotation);
        //    print(cards.transform.GetChild(i).transform.localEulerAngles);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(!isTutorial && cards.activeSelf){
            tutorial.SetActive(true);
            isTutorial = true;
        }
    }

    public void pickUp(GameObject card)
    {
        // put the card onto the hand
        for(int i = 0; i < 3; i++)
        {
            cards.transform.GetChild(i).gameObject.SetActive(true);        
            StartCoroutine(disappear(card.transform.GetChild(i).gameObject));
        } 
        card.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();     
    }

    public void leaveHand(GameObject card){
        // put the card out of the hand
        card.transform.parent = gameObject.transform;
    }

    public void moveOut(GameObject card)
    {
        // duplicate a card
        int posIdx = int.Parse(card.name);
        GameObject card2 = GameObject.Instantiate(card, cards.transform);
        card2.name = posIdx.ToString();
        card2.transform.localPosition = pos[posIdx];
        card2.transform.localRotation = rot[posIdx];

        card.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
        StartCoroutine(rotate(posIdx));
        StartCoroutine(disappear(card));
    }

    IEnumerator rotate(int idx)
    {
        yield return new WaitForSeconds(1.5f);
        rotateRoom.rotate(idx);
    }

    IEnumerator disappear(GameObject card)
    {
        yield return new WaitForSeconds(2f);
        card.SetActive(false);
    }
}
