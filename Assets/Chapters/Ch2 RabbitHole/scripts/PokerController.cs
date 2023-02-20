using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerController : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject cards;
    public Vector3[] pos;
    public Quaternion[] rot;
    public GameObject handGesture;
    public bool useTutorial;
    
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
        if(useTutorial && !isTutorial && cards.activeSelf){
            tutorial.SetActive(true);
            isTutorial = true;
        }
    }

    public void pickUp(GameObject card)
    {
        for(int i = 0; i < 3; i++)
        {
            cards.transform.GetChild(i).gameObject.SetActive(true); 
        } 
        card.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
        StartCoroutine(disappear(card));    
        // handGesture.SetActive(false);
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
        card2.transform.localScale = new Vector3(1f, 1f, 1f);

        card.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
        StartCoroutine(rotate(posIdx, card.transform.position));
        StartCoroutine(disappear(card));
    }

    IEnumerator rotate(int idx, Vector3 src)
    {
        print("poker "+ src);
        yield return new WaitForSeconds(1.5f);
        rotateRoom.rotate(idx, src);
    }

    IEnumerator disappear(GameObject card)
    {
        yield return new WaitForSeconds(2f);
        card.SetActive(false);
    }
}
