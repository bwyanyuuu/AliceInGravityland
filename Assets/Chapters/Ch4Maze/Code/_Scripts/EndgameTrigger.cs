using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndgameTrigger : MonoBehaviour
{
    //[SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private GameObject _player;

    private Rigidbody _rigidbody;
    private ArmSwingMoverMaze _armSwingMoverMaze;

    [SerializeField] private float _fallingDownSpeed;
    [SerializeField] private float _fallingDownSeconds;
    
    //[SerializeField] private Animator black;
    private bool isEnabled = false;


    private void Start()
    {
        _armSwingMoverMaze = _player.GetComponent<ArmSwingMoverMaze>();
        _rigidbody = _player.GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!isEnabled && other.CompareTag("Player"))
        {
            isEnabled = true;
            StartCoroutine(EndgameSequence());
        }
    }

    IEnumerator EndgameSequence()
    {
        // Disable movement
        _armSwingMoverMaze.enabled = false;
        
        // Drop down by constant velocity
        _rigidbody.useGravity = false;
        _rigidbody.velocity = _fallingDownSpeed * Vector3.down;
        
        // Wait for seconds
        yield return new WaitForSeconds(_fallingDownSeconds);

        // Load next level
        //_levelLoader.LoadNextLevel();

        // Load next level, via CCCC's code
        gameObject.GetComponent<LevelLoader>().load();
    }
}
