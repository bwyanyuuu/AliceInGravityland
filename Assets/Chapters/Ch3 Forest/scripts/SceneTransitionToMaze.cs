using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionToMaze : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelLoader.LoadNextLevel();
        }
    }
}
