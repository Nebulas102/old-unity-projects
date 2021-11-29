using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnityAdHelper : MonoBehaviour
{
    public void ShowRewardedAd()
    {

        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
        else {
            GameObject.Find("Revive").transform.GetChild(0).GetComponent<Text>().color = Color.grey;
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                this.returnToGame();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                SceneManager.LoadScene(0);
                break;
        }
    }

    private void returnToGame()
    {
        GameObject.Find("God").GetComponent<GameEventController>().revived = true;
        GameObject.Find("GameOver").SetActive(false);
        GameObject planet = GameObject.Find("Planet");
        planet.transform.position = new Vector3(0, 0, 0);
        planet.GetComponent<Planet>().Heal(1);

        Debug.Log(Time.timeScale);
        Time.timeScale = 1 + (0.1f * planet.GetComponent<Planet>().tier);
        Debug.Log(planet.GetComponent<Planet>().tier);
        Debug.Log(Time.timeScale);
    }
}
