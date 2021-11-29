using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    public GameObject playerHead;
    public GameObject playerBody;
    public GameObject weapon;
    public Text text;
    public float score;

    private bool click = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerHead.transform.localPosition = new Vector2(0, -1.5f);
            playerBody.transform.localPosition = new Vector2(0, -2f);
            //playerBody.transform.localScale = new Vector3(0.7f, 0.5f, 0.7f);
            this.click = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            playerHead.transform.localPosition = new Vector2(0, 0);
            playerBody.transform.localPosition = new Vector2(0, -1.4f);
            this.click = false;
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("Click");
                playerHead.transform.localPosition = new Vector2(0, -1.5f);
                playerBody.transform.localPosition = new Vector2(0, -2f);
                this.click = true;
            }
        } /*else if (this.click == true)
        {
            Debug.Log("Release");

            playerHead.transform.localPosition = new Vector2(0, 0);
            playerBody.transform.localPosition = new Vector2(0, -1.4f);
            this.click = false;
        }*/


        if (!click && playerHead)
        {
            this.score += Time.deltaTime;
            //this.score += Time.deltaTime * weapon.GetComponent<RotationWeapon>().swing;
        }

        text.text = score.ToString("F1");
    }
}
