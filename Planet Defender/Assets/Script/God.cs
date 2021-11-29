using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class God : MonoBehaviour {

    public GameObject rocket;
    public Text text;
    public string baseText;

    public float cooldown;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

            if (this.rocket != null && this.checkTouchOnGameObject(position))
            {
                rocket.GetComponent<BaseRocket>().target = position;
                rocket.GetComponent<BaseRocket>().selected = true;
            }

            this.rocket = this.checkTouch(position);
        }

        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Touch touch = Input.GetTouch(0);


            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            if (this.rocket != null && this.checkTouchOnGameObject(position))
            {
                rocket.GetComponent<BaseRocket>().target = position;
                rocket.GetComponent<BaseRocket>().selected = true;
            }

            this.rocket = this.checkTouch(position);
        }
    }

    private GameObject checkTouch(Vector3 pos)
    {
        Vector2 touchPos = new Vector2(pos.x, pos.y);
        var hit = Physics2D.OverlapPoint(touchPos);

        if (hit)
        {
            if (hit.gameObject.tag.Equals("Rocket"))
            {
                if (hit.gameObject.GetComponent<BaseRocket>().selected == false)
                {
                    return hit.gameObject;
                }
            }
        }

        return null;
    }

    private bool checkTouchOnGameObject(Vector3 pos)
    {
        GameObject hit = this.checkTouch(pos);

        if (hit != null)
        {
            if (hit.gameObject != rocket)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    public void updateScore(int score) {
        this.text.text = baseText + "\n " + score;
    }
}
