using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PockerController : MonoBehaviour
{
    public GameObject cards;
    public Vector3[] pos;
    public Quaternion[] rot;
    private RotateRoom rotateRoom;
    // Start is called before the first frame update
    void Start()
    {
        rotateRoom = gameObject.GetComponent<RotateRoom>();
        //print("hhh");
        //for (int i = 0; i < 5; i++)
        //{
        //    trans.Add(cards.transform.GetChild(i).gameObject.transform.position);
        //    //print(i);
        //}
        //card = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //print("sss");
    }
    public void moveOut(GameObject card)
    {
        int idx = int.Parse(card.name);
        GameObject card2 = GameObject.Instantiate(card, cards.transform);
        card2.name = idx.ToString();
        card2.transform.localPosition = pos[idx];
        card2.transform.localRotation = rot[idx];
        //card2.transform.rotation = trans[idx].rotation;
        //card2.SetActive(true);
        card.transform.parent = gameObject.transform;
        //card.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true;
        card.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
        //card.GetComponent<UnityEngine.Playables.PlayableDirector>().enabled = true;


        //emit.GetComponent<CurlNoiseParticleSystem.Emitter.ShapeEmitter>().Emit();
        StartCoroutine(disappear(idx));
    }
    IEnumerator disappear(int idx)
    {
        yield return new WaitForSeconds(1.5f);
        rotateRoom.rotate(idx);
    }
}
