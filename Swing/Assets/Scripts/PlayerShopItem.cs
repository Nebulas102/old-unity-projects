using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShopItem : ShopItem
{
    public PlayerSkin playerSkin;
    public List<GameObject> buttons;

    public void Awake()
    {
        this.nameUI.text = playerSkin.name;
        this.priceUI.text = playerSkin.price + " pt";
        GameObject preview = Instantiate(playerSkin.skin, prefab.transform.position, Quaternion.identity, prefab.transform);
        preview.transform.Rotate(0, 160, 0);
        preview.transform.localScale = new Vector3(10, 10, 10);
        preview.transform.localPosition = new Vector3(0, 0, -40);

        ShopKeeper.refreshAll();
    }

    public void checkStatus() {
        PlayerSkin currentSkin = new PlayerSkin();
        if (SaveHelper.FileExists("PlayerSkin"))
        {
            JsonUtility.FromJsonOverwrite(SaveHelper.LoadDataFromFile("PlayerSkin"), currentSkin);
        }

        BoughtSkins bought;
        if (SaveHelper.FileExists("boughtSkins"))
        {
            bought = JsonUtility.FromJson<BoughtSkins>(SaveHelper.LoadDataFromFile("boughtSkins"));
        }
        else
        {
            bought = new BoughtSkins();
            bought.playerSkins = new List<PlayerSkin>();
        }

        bool found = false;
        foreach (PlayerSkin skin in bought.playerSkins)
        {
            if (skin.skin == playerSkin.skin)
            {
                found = true;
            }
        }
       
        if (found)
        {

            if (playerSkin.skin != currentSkin.skin)
            {
                buttons[0].SetActive(false);
                buttons[1].SetActive(true);
                buttons[2].SetActive(false);
            }
            else {
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(true);
            }
        }
        else
        {
            buttons[1].SetActive(false);
            buttons[0].SetActive(true);
            buttons[2].SetActive(false);
        }
    }

    public void buyPlayerSkin() {
        if ((ShopKeeper.score.totalScore - playerSkin.price) >= 0)
        {
                ShopKeeper.score.totalScore -= playerSkin.price;

                SaveHelper.WriteDataToFile("score", JsonUtility.ToJson(ShopKeeper.score));

            BoughtSkins bought;
            if (SaveHelper.FileExists("boughtSkins"))
            {

                bought = JsonUtility.FromJson<BoughtSkins>(SaveHelper.LoadDataFromFile("boughtSkins"));
            }
            else
            {
                bought = new BoughtSkins();
                bought.playerSkins = new List<PlayerSkin>();
            }

            bought.playerSkins.Add(playerSkin);

                SaveHelper.WriteDataToFile("boughtSkins", JsonUtility.ToJson(bought));
            }
        ShopKeeper.refreshAll();
    }

    public void selectPlayerSkin() {
        SaveHelper.WriteDataToFile("PlayerSkin", JsonUtility.ToJson(playerSkin));
        ShopKeeper.refreshAll();
    }
}
