using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLevelSelect : MonoBehaviour {

    public GameObject MenuManager;
    bool LevelSelectActive = false;

    public void ToggleLevelSelect()
    {
        MenuManager.GetComponent<ChristmasController>().changeCalendarMode(LevelSelectActive);
        LevelSelectActive = !LevelSelectActive;
    }
}
