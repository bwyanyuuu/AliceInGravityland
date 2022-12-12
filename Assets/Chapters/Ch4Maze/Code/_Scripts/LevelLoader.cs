using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator _transition;
    private float transitionTime = 1f;

    public void LoadNextLevel()
    {
        print("load");
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //int nextSceneIndex = currentSceneIndex + 1;
        //if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        //{
        //    nextSceneIndex = 0;
        //}
        //StartCoroutine(LoadLevel(nextSceneIndex));
        _transition.SetTrigger("fadeoutt");
        StartCoroutine(changeScene());
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
    IEnumerator changeScene()
    {
        //var sc = SceneManager.GetActiveScene();
        //GameObject[] g = sc.GetRootGameObjects();
        //for (int i = 0; i < g.Length; i++)
        //{
        //    if (!g[i].CompareTag("Player")) Destroy(g[i]);
        //}
        //UnityEditor.EditorUtility.UnloadUnusedAssetsImmediate();
        print(SceneManager.GetActiveScene().buildIndex + 1);
        var name = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name;
        AsyncOperation op = SceneManager.LoadSceneAsync("Ch4 Maze");
        op.allowSceneActivation = false;
        while (op.progress < 1f)
        {
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }
}
