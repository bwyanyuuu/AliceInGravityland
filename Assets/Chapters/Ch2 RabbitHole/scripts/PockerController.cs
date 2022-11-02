using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PockerController : MonoBehaviour
{
    public GameObject cards;
    //private List<Vector3> trans = new List<Vector3>();
    public Vector3[] pos;
    public Quaternion[] rot;
    //private GameObject card;
    private RotateRoom rotateRoom;
    public GameObject emit;
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
    public void hoverColor()
    {
        //card.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
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
        //rotateRoom.rotate(idx);
        
        //emit.GetComponent<CurlNoiseParticleSystem.Emitter.ShapeEmitter>().Emit();
        StartCoroutine(disappear(card));
    }
    IEnumerator disappear(GameObject card)
    {
        yield return new WaitForSeconds(1);
        card.SetActive(false);
        yield return new WaitForSeconds(2);
        card.GetComponent<CurlNoiseParticleSystem.Emitter.ShapeEmitter>().Emit();
    }
}
