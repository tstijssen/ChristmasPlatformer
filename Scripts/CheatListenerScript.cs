using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatListenerScript : MonoBehaviour {

    // cheat variables
    private CheatCode AllLevels;
    private CheatCode ResetLevels;

    // Use this for initialization
    void Start () {
        AllLevels.index = 0;
        ResetLevels.index = 0;

        // cheat code to unlock all levels is "santa"
        AllLevels.code = new string[] { "s", "a", "n", "t", "a" };

        // code to reset unlocked levels is "reset"
        ResetLevels.code = new string[] { "r", "e", "s", "e", "t" };

    }

    // Update is called once per frame
    void Update () {

        string frameInput = Input.inputString;

        if (frameInput == AllLevels.code[AllLevels.index])
            AllLevels.index++;

        // is cheat complete?
        if (AllLevels.index == AllLevels.code.Length)
        {
            PlayerPrefs.SetInt("LevelsDone", 25);
            AllLevels.index = 0;
            Debug.Log("All Levels Unlocked!");
        }

        if (frameInput == ResetLevels.code[ResetLevels.index])
            ResetLevels.index++;

        // is cheat complete?
        if (ResetLevels.index == ResetLevels.code.Length)
        {
            PlayerPrefs.SetInt("LevelsDone", 0);
            ResetLevels.index = 0;
            Debug.Log("Level Unlocks Reset!");
        }


    }

    struct CheatCode
    {
        public string[] code;
        public int index;
    }
}
