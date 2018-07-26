using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    bool loadingScene;
    string levelName;

    public Slider loadingSlider;
    // Use this for initialization
    void Start () {
        levelName = PlayerPrefs.GetString("LoadScene");
        loadingScene = false;
        StartCoroutine(LoadNewScene());
    }

    // Update is called once per frame
    void Update () {
    }

    IEnumerator LoadNewScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
        //async.allowSceneActivation = false;

        loadingScene = true;
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");
            loadingSlider.value = progress;

            yield return null;
        }
    }
}
