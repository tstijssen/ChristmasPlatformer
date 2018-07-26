using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text ScoreText;
    public Text LivesText;
    public Text TimeText;
	// Use this for initialization
	void Start () {
		
	}
	


	// Update is called once per frame
	void Update () {
        ScoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        LivesText.text = "Lives: " + PlayerPrefs.GetInt("Lives");
        TimeText.text = "Time: " + PlayerPrefs.GetFloat("Time").ToString("0") + " seconds";
    }
}
