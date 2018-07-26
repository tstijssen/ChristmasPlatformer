using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

//public class PlayerProgress
//{
//    public int highestScore = 0;

//}


//public class DataController : MonoBehaviour {

//    private PlayerProgress playerProg;

//    private string gameDataFileName = "data.json";

//	// Use this for initialization
//	void Start () {
//        DontDestroyOnLoad(gameObject);

//        LoadGameData();
//        LoadPlayerProgress();

        
//	}

//    public void SubmitNewPlayerScore(int newScore)
//    {
//        if (newScore > playerProg.highestScore)
//        {
//            playerProg.highestScore = newScore;
//            SavePlayerProgress();
//        }
//    }
	
//    public int GetHighestPlayerScore()
//    {
//        return playerProg.highestScore;
//    }

//    private void LoadGameData()
//    {
//        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

//        if(File.Exists(filePath))
//        {
//            // read json file into string
//            string dataAsJson = File.ReadAllText(filePath);

//            GameD
//        }
//    }

//	// Update is called once per frame
//	void Update () {
		
//	}
//}
