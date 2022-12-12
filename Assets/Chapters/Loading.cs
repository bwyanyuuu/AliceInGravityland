using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Loading : MonoBehaviour
{
    public GameObject background;
    public TextMeshPro percentage;
    public GameObject all;

    private Animation fade;
    //private Text percent;
    private string scene;
    private bool isLoading = false;
    //private bool isStarting = true;
    //void Awake()
    //{
    //    GameObject[] objs = GameObject.FindGameObjectsWithTag("Loading");
    //    if (objs.Length > 1)
    //    {
    //        Destroy(this.gameObject);
    //    }

    //    DontDestroyOnLoad(this.gameObject);
    //}

    void Start()
    {
        fade = background.GetComponent<Animation>();
        //percent = percentage.GetComponent<Text>();
        fade.Play("fadeOut");
    }

    void Update()
    {
        if(isLoading && !fade.isPlaying)
        {
            isLoading = false;
            all.SetActive(true);
            AudioSource[] l = GameObject.FindObjectsOfType<AudioSource>();
            for (int i = 0; i < l.Length; i++)
            {
                l[i].Stop();
            }

            var sc = SceneManager.GetActiveScene();
            GameObject[] g = sc.GetRootGameObjects();
            for (int i = 0; i < g.Length; i++)
            {
                if (!g[i].CompareTag("OVR")) Destroy(g[i]);
            }
            UnityEditor.EditorUtility.UnloadUnusedAssetsImmediate();
            StartCoroutine(StartLoading(scene));
        }
        //if(isStarting && !fade.isPlaying)
        //{
        //    //background.SetActive(false);
        //    isStarting = false;
        //}
    }
    private void SetLoadingPercentage(int p)
    {
        percentage.text = p.ToString();
    }
    private IEnumerator StartLoading(string name)
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync(name);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        all.SetActive(false);
        op.allowSceneActivation = true;
        //fade.Play("fadeOut");
        Destroy(gameObject);
    }
    public void loadScene(string name)
    {
        //background.SetActive(true);
        fade.Play("fadeIn");
        scene = name;
        isLoading = true;
    }
}
