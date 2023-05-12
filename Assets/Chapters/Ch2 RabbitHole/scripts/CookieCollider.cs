using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieCollider : MonoBehaviour
{
    public GameObject room;
    public float roomScale;
    public float speed;
    private GameObject player;
    public GameObject mirror;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.parent.parent.gameObject;
        audioData = GetComponent<AudioSource>();
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
            audioData.Play();
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
        float stepMirror = (23.93f - mirror.transform.position.y) / speed;
        for (int i = 0; i < speed; i++)
        {
            //print(1 + i * step);

            room.transform.localScale += new Vector3(step, step, step);

            player.transform.position = pos * (1 + i * step);
            mirror.transform.position = new Vector3(mirror.transform.position.x, mirror.transform.position.y + stepMirror, mirror.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}
