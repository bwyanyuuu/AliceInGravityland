using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public GameObject wall;
    public Animator sphere;
    public LevelLoader cutScene;
    private GameMaster gameMaster;
    private bool ishahaed = false;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wall.GetComponent<Collider>().enabled = false;
            if (!ishahaed)
            {
                StartCoroutine(ha());
            }
            
            
            //gameMaster.nxt = true;
        }
    }
    IEnumerator ha(){
        sphere.SetBool("fadeout", true);
        //Invoke("haha", 0.01f);
        yield return new WaitForSeconds(0.01f);
        sphere.SetBool("fadeout", false);
        ishahaed = true;
        cutScene.LoadNextLevel();
    }
    private void haha()
    {
        sphere.SetBool("fadeut", false);
    }
}
