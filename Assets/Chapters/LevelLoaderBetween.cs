using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderBetween : MonoBehaviour
{
    [SerializeField] private Animator black;
    private float transitionTime = 1f;
    private bool isEnabled = false;
    void Start()
    {
        isEnabled = true;
        black.SetTrigger("fadeOut");
        StartCoroutine(changeScene());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isEnabled && other.CompareTag("Player"))
        {
            isEnabled = true;
            black.SetTrigger("fadeOut");
            StartCoroutine(changeScene());
        }
    }
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

        //black.SetTrigger("fadeoutt");
        //StartCoroutine(changeScene());
    }
    public void load()
    {
        black.SetTrigger("fadeOut");
        StartCoroutine(changeScene());
    }
    IEnumerator LoadLevel(int sceneIndex)
    {
        black.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(2.1f);

        var sc = SceneManager.GetActiveScene();
        GameObject[] g = sc.GetRootGameObjects();
        for (int i = 0; i < g.Length; i++)
        {
            if (!g[i].CompareTag("Player")) Destroy(g[i]);
            //print(g[i].tag);
        }
        UnityEditor.EditorUtility.UnloadUnusedAssetsImmediate();

        AsyncOperation async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //async.allowSceneActivation = false;
        while (!async.isDone)
        {
            //print(async.progress);
            if(async.progress >= 0.9f) break;
            yield return null;
        }
        //async.allowSceneActivation = true;
    }
}
