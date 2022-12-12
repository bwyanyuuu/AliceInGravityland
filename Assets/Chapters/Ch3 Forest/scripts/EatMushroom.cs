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
    public float envScale;
    public float speed;
    private bool isGrabbing = false;
    private bool isSmalling = false;
    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isGrabbing && other.name == "EatCollider")
        {
            // Play a funny eating sound
            //audioData.Play();

            // Disable mushroom and bubble
            // Activate gate            
            bubble.SetActive(false);
            magicGate.SetActive(true);
            player.GetComponent<ZeroGravity>().enabled = false;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<ArmSwingMover>().enabled = true;
            StartCoroutine(envSmaller());

            
            // Let Alice fall to ground
            // Play animation of getting up
            // How to resize world ?
            
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
            //Vector3 oriSize1 = terrains[0].terrainData.size;
            //Vector3 oriSize2 = terrains[1].terrainData.size;
            for (int i = 0; i < speed; i++)
            {
                environment.transform.localScale -= new Vector3(step, step, step);
                player.transform.position = new Vector3(pos.x * (1 - i * step), player.transform.position.y, pos.z * (1 - i * step));
                yield return new WaitForSeconds(0.01f);
            }
            //print(step + " " + (1 - speed * step));
            //print(terrains[0].terrainData.size);
            //print(terrains[1].terrainData.size);
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
