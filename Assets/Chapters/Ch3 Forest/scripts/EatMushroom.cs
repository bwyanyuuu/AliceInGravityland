using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class EatMushroom : MonoBehaviour
{
    public GameObject magicGate;
    public GameObject bubble;
    public GameObject player;
    public GameObject environment;
    public GameObject guideTrail1;
    public GameObject guideTrail2;
    public GameObject[] Deleteterrain;
    
    public float envScale;
    public float speed;
    private bool isGrabbing = false;
    private bool isSmalling = false;
    AudioSource audioData;

    //[SerializeField] private GameObject sceneTransitionTrigger;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // if (isGrabbing && other.name == "EatCollider")
        if (other.name == "EatCollider")
        {
            // Play a funny eating sound
            StartCoroutine(envSmaller());
            audioData.Play();
            Debug.Log("testing");
            // Disable mushroom and bubble
            // Activate gate            
            bubble.SetActive(false);
            magicGate.SetActive(true);
            guideTrail1.SetActive(false);
            guideTrail2.SetActive(true);
            //sceneTransitionTrigger.SetActive(true);
            player.GetComponent<ZeroGravity>().enabled = false;
            player.GetComponent<ArmSwingMover>().enabled = true;
            // falling and load to next scene
            for (int i = 0; i < Deleteterrain.Length; i++) {
                Deleteterrain[i].GetComponent<Collider>().enabled = false;
            }
        }
    }
    IEnumerator envSmaller()
    {
        if (!isSmalling)
        {
            isSmalling = true;
            Vector3 pos = player.transform.position;
            print("player " + pos);
            player.transform.parent = null;
            float step = (1f-envScale) / speed;
            print(step);
            for (int i = 0; i < speed; i++)
            {
                if(i == 45) player.GetComponent<Rigidbody>().useGravity = true;
                environment.transform.localScale -= new Vector3(step, step, step);
                print(environment.transform.localScale);
                player.transform.position = new Vector3(pos.x * (1 - i * step), player.transform.position.y, pos.z * (1 - i * step));
                yield return new WaitForSeconds(0.01f);
            }
            print("player after " + player.transform.position);

            transform.parent.gameObject.SetActive(false);
            isSmalling = false;
        }
        
    }
    public void setGrab(bool b)
    {
        isGrabbing = b;
    }
}
