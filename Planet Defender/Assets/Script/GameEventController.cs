using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEventController : MonoBehaviour
{
    public GameObject gameover;
    public string BaseScore, BaseBest;
    public bool revived = false;

    public void Start()
    {
        gameover.SetActive(false);
    }

    // Update is called once per frame
    public void GameOver(int score)
    {
        GameObject.Find("Planet").transform.position = new Vector3(0, 0, 100);
        gameover.SetActive(true);

        if (this.revived == true)
        {
            GameObject.Find("Revive").transform.GetChild(0).GetComponent<Text>().color = Color.grey;
        }

        Time.timeScale = 0f;

        int highscore = 0;
        if (SavingController.FileExists("score"))
        {
            ScoreSystem scoreController = JsonUtility.FromJson<ScoreSystem>(SavingController.LoadDataFromFile("score"));
            highscore = scoreController.highscore;
        }
        GameObject.Find("Score").GetComponent<Text>().text = this.BaseScore + "\n" + score;
        GameObject.Find("Best").GetComponent<Text>().text = this.BaseBest + "\n" + (score > highscore ? score : highscore);

        this.SaveGame(score);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void Revive()
    {
        if (this.revived == false)
        {
            UnityAdHelper ad = new UnityAdHelper();
            ad.ShowRewardedAd();

            foreach (GameObject rocket in GameObject.FindGameObjectsWithTag("Rocket"))
            {
                Destroy(rocket);
            }
        }
    }

    private void SaveGame(int score)
    {
        ScoreSystem scoreController = null;
        if (SavingController.FileExists("score"))
        {
            scoreController = JsonUtility.FromJson<ScoreSystem>(SavingController.LoadDataFromFile("score"));
        }

        if (scoreController != null)
        {
            if (score > scoreController.highscore)
            {
                scoreController.highscore = score;
            }
        }
        else
        {
            scoreController = new ScoreSystem();
            scoreController.highscore = score;
        }
        scoreController.totalScore += score;

        SavingController.WriteDataToFile("score", JsonUtility.ToJson(scoreController));
    }
}
