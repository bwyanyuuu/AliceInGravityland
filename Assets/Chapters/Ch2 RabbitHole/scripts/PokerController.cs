using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerController : MonoBehaviour
{
    public GameObject cards;
    public Vector3[] pos;
    public Quaternion[] rot;
    public GameObject[] cardsOutside;
    public Material[] cardsMaterial;
    private RotateRoom rotateRoom;
    private List<int> cardOwned = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
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
        //print("sss");
    }
    
    public void showCard(int idx)
    {
        cardsOutside[idx].SetActive(true);
    }

    public void pickUp(GameObject card)
    {
        print("pickUp");
        // put the card onto the hand
        int idx = -1;
        for(int i = 0; i < cardsOutside.Length; i++)
        {
            if(card == cardsOutside[i])
            {
                idx = i;
                break;
            }
        }
        print(idx);
        if(idx != -1)
        {
            print(cardOwned.Count);
            GameObject c = cards.transform.GetChild(cardOwned.Count).gameObject;
            c.SetActive(true);
            c.transform.GetChild(0).GetComponent<Renderer>().material = cardsMaterial[idx];
            cardOwned.Add(idx);
            card.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
            StartCoroutine(disappear(card));
        }        
    }
    public void moveOut(GameObject card)
    {
        // duplicate a card
        int posIdx = int.Parse(card.name);
        GameObject card2 = GameObject.Instantiate(card, cards.transform);
        card2.name = posIdx.ToString();
        card2.transform.localPosition = pos[posIdx];
        card2.transform.localRotation = rot[posIdx];
        // put the card out of the hand
        card.transform.parent = gameObject.transform;
        card.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
        StartCoroutine(rotate(cardOwned[posIdx]));
        StartCoroutine(disappear(card));
    }
    IEnumerator rotate(int idx)
    {
        yield return new WaitForSeconds(1.5f);
        rotateRoom.rotate(idx);

    }
    IEnumerator disappear(GameObject card)
    {
        yield return new WaitForSeconds(1.5f);
        card.SetActive(false);
        // GameObject.Destroy(card);
    }
}
