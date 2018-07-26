using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores
{
    public int score;
    public string name;
    public float time;

}
public class Scoreboard : MonoBehaviour {

    string scoreboardText = "";
    private const int LeaderboardLength = 10;

    public Text HighScoresLeft;
    public Text HighScoresCenter;
    public Text HighScoresRight;

    // Use this for initialization
    void Start () {

    }

    public void PopulateScoreBoard()
    {
        Debug.Log("Getting Scores");

        List<Scores> HighScores = GetHighScore();

        foreach (Scores s in HighScores)
        {
            if (HighScores.IndexOf(s) > 8)
            {
                HighScoresRight.text += "[" + (HighScores.IndexOf(s) + 1) + "] " + s.name + ": " + s.score + "\n";
            }
            else if (HighScores.IndexOf(s) > 4)
            {
                HighScoresCenter.text += "[" + (HighScores.IndexOf(s) + 1) + "] " + s.name + ": " + s.score + "\n";
            }
            else
            {
                HighScoresLeft.text += "[" + (HighScores.IndexOf(s) + 1) + "] " + s.name + ": " + s.score + "\n";
                Debug.Log(HighScoresLeft.text);
            }
        }
    }

    public List<Scores> GetHighScore()
    {
        List<Scores> HighScores = new List<Scores>();
        int i = 1;
        while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            Scores temp = new Scores();
            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
            i++;
        }
        return HighScores;
    }
}
