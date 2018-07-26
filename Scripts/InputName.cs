using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start () {
        text.text = "Game Over! \n Your score is: " + PlayerPrefs.GetInt("Score") + "!";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
