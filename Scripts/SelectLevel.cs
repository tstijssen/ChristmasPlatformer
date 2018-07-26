using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevel : MonoBehaviour {

    string levelName;
    private void Start()
    {
        levelName = "Level" + this.name.Substring(name.Length - 2);
    }
    private void OnMouseDown()
    {
        PlayerPrefs.SetString("LoadScene", levelName);
        SceneManager.LoadScene("LoadingScreen");
    }
}
