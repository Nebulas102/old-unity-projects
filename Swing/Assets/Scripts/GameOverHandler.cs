using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    public List<Text> text;

    private void Awake()
    {
        Score score = JsonUtility.FromJson<Score>(SaveHelper.LoadDataFromFile("score"));
        text[0].text = "Total:" + Mathf.FloorToInt(score.totalScore) + "pt";
        text[1].text = "Your score: " + Mathf.FloorToInt(score.lastScore);
        text[2].text = "Best score: " + Mathf.FloorToInt(score.bestScore);
    }
}
