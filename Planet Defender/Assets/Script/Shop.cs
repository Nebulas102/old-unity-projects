using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text score;
    public string baseText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem scoreSystem = JsonUtility.FromJson<ScoreSystem>(SavingController.LoadDataFromFile("score"));
        score.text = baseText + ": " + scoreSystem.totalScore;
    }
}
