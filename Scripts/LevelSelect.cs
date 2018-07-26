using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {
    private string[] cheatCode;
    private int index;
    public AudioClip MenuMusic;
    public AudioClip GameMusic;
    public AudioClip LoseMusic;

    AudioSource source;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
        index = 0;

        // cheat code to unlock all levels is "drummers"
        cheatCode = new string[] { "d", "r", "u", "m", "m", "e", "r", "s" };

        // start menu music
        PlayMenuMusic();
    }

    public void PlayMenuMusic()
    {
        source.Stop();
        source.clip = MenuMusic;
        source.Play();
    }

    public void PlayGameMusic()
    {
        source.Stop();
        source.clip = GameMusic;
        source.Play();
    }

    public void PlayLoseMusic()
    {
        source.Stop();
        source.clip = LoseMusic;
        source.Play();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        if (index == cheatCode.Length)
        {
            // unlock all levels
        }
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

}
