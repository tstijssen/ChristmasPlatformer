using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScreenButton : MonoBehaviour {

    public GameObject player;
    public GameObject screen;

    public void StartGame()
    {
        player.SetActive(true);
        screen.SetActive(false);
    }
}
