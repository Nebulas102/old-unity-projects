using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    public Score score;
    public Text coins;
    public List<PlayerShopItem> items;

    private void Start()
    {
        this.score = JsonUtility.FromJson<Score>(SaveHelper.LoadDataFromFile("score"));
        
        this.coins.text = Mathf.FloorToInt(score.totalScore) + "pt";
    }

    public void refreshAll() {
        this.coins.text = Mathf.FloorToInt(score.totalScore) + "pt";
        foreach (PlayerShopItem item in items) {
            item.checkStatus();
        }
    }
}
