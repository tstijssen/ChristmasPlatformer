using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadScene()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public GameObject player;
    public GameObject screen;
    public InputField input;

    public void StartGame()
    {
        player.SetActive(true);
        screen.SetActive(false);
    }

    public void RestartOrNext()
    {
        PlayerPrefs.SetInt("Score", 0); // reset score
        SceneManager.LoadScene("LoadingScreen");
    }

    // update highscores
    public void AddScore()
    {
        PlayerPrefs.SetString("Name", input.text);
        player.GetComponent<QueryLocomotionController>().SaveHighScore(PlayerPrefs.GetString("Name"), PlayerPrefs.GetInt("Score"));
    }

    public void EndGame()
    {
        PlayerPrefs.SetInt("Score", 0); // reset score
        PlayerPrefs.SetString("LoadScene", "Menu");
        SceneManager.LoadScene("LoadingScreen");

    }
}
