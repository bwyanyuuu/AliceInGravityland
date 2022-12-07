using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieCollider : MonoBehaviour
{
    public GameObject room;
    public float roomScale;
    public float speed;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if (other.CompareTag("cookie"))
        {
            other.gameObject.SetActive(false);
            StartCoroutine(roomBigger());
        }
    }
    IEnumerator roomBigger()
    {
        //print("big"+ player.name);
        Vector3 pos = player.transform.position;
        player.transform.parent = null;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        float step = roomScale / speed;
        for (int i = 0; i < speed; i++)
        {
            //print(1 + i * step);

            room.transform.localScale += new Vector3(step, step, step);
            player.transform.position = pos * (1 + i * step);
            yield return new WaitForSeconds(0.01f);
        }
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
