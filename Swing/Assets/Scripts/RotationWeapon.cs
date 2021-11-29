using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWeapon : MonoBehaviour
{
    public float speed;
    public int swing = 1;

    public WeaponSkin skin;
    public GameObject weapon;

    /*public void Awake()
    {
        SaveHelper.WriteDataToFile("WeaponSkin", JsonUtility.ToJson(skin));
        //this.skin = JsonUtility.FromJson<WeaponSkin>(SaveHelper.LoadDataFromFile("skins"));
        JsonUtility.FromJsonOverwrite(SaveHelper.LoadDataFromFile("WeaponSkin"), this.skin);
        GameObject blade = Instantiate(skin.skin, skin.skin.transform.position, Quaternion.identity, weapon.transform);
        blade.transform.localPosition = new Vector2(0 ,0);
    }*/

    // Update is called once per frame
    void Update()
    {

        if (transform.eulerAngles.z >= 90 && transform.eulerAngles.z <= 200)
        {
            this.speed = -Random.Range(30, 200);
            this.swing++;
        }
        else if (transform.eulerAngles.z <= 270 && transform.eulerAngles.z >= 200)
        {
            this.speed = Random.Range(30, 200);
            this.swing++;
        }

        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
