using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionToMaze : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    private bool isEnter = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isEnter && other.CompareTag("Player"))
        {
            isEnter = true;
            levelLoader.LoadNextLevel();
        }
    }
}
