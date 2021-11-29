using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHead : MonoBehaviour
{
    public Duck player;
    public RotationWeapon weapon;

    public PlayerSkin skin;

    public void Awake()
    {
        if (!SaveHelper.FileExists("PlayerSkin"))
        {
            SaveHelper.WriteDataToFile("PlayerSkin", JsonUtility.ToJson(skin));
        }

        skin = new PlayerSkin();

        JsonUtility.FromJsonOverwrite(SaveHelper.LoadDataFromFile("PlayerSkin"), this.skin);

        GameObject head = Instantiate(skin.skin, skin.skin.transform.position, skin.skin.transform.rotation, transform);
        head.transform.localPosition = skin.skin.transform.position;
        head.transform.localRotation = skin.skin.transform.rotation;

        this.player = GameObject.Find("Player").GetComponent<Duck>();
        this.weapon = GameObject.Find("Weapon").GetComponent<RotationWeapon>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag.Equals("Weapon"))
        {
            Score score;
            if (SaveHelper.FileExists("score")) {
                Debug.Log("old");
                score = JsonUtility.FromJson<Score>(SaveHelper.LoadDataFromFile("score"));
                Debug.Log(score.totalScore);
                score.totalScore += player.score;
                score.lastScore = player.score;

                if (score.bestScore < player.score) {
                    score.bestScore = player.score;
                }

                if (score.bestSwing < weapon.swing) {
                    score.bestSwing = weapon.swing;
                }
            } else {
                Debug.Log("new");
                score.totalScore = player.score;
                score.bestScore = player.score;
                score.bestSwing = weapon.swing;
                score.lastScore = player.score;

                score.totalScore.ToString("F2");
            }

            SaveHelper.WriteDataToFile("score", JsonUtility.ToJson(score));
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
