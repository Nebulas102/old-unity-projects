using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRocket : MonoBehaviour {

    public int health;
    public int score;
    public int damage;
    public float speed;
    private float rotationSpeed = 4;

    public bool selected;

    public Vector3 target;
    private GameObject planet;

    private float countdown;
    private bool disable;

    private void Awake()
    {
        this.planet = GameObject.Find("Planet");
    }

    private void Start () {
	    this.target = this.planet.transform.position;
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, this.target - this.transform.position);
    }
	
	public void Update () {

        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, this.target - this.transform.position);
        Quaternion transformRotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Vector3.forward, this.target - this.transform.position), (this.rotationSpeed / 2) * Time.deltaTime);

        if (planet.transform.position == target)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.target, this.speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Vector3.forward, this.target - this.transform.position), this.speed * Time.deltaTime);
        }
        else
        {
            if (this.disable == false)
            {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(Vector3.forward, this.target - this.transform.position), (this.rotationSpeed * 2) * Time.deltaTime);
                //this.transform.position += this.transform.up * ((this.speed / 3f) * Time.deltaTime);
                if (this.transform.rotation == transformRotation)
                {
                    this.disable = true;
                }
            }
            else
            {
                this.transform.position += (this.transform.up * 1.5f) * (this.speed * Time.deltaTime);
            }
        }

        this.checkIfOutsideMap();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Planet"))
        {
            collision.gameObject.GetComponent<Planet>().health -= damage;
            collision.gameObject.GetComponent<Planet>().Damage();
            Destroy(this.gameObject);
        }

        /*if (collision.gameObject.tag.Equals("Rocket"))
        {
            Debug.Log(collision.gameObject);
            Destroy(this.gameObject);
        }*/
    }

    private void checkIfOutsideMap() {
        Vector2 CameraScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if (((this.transform.position.x - (this.transform.localScale.y * 2)) > CameraScreen.x || (this.transform.position.x + (this.transform.localScale.y * 2)) < -CameraScreen.x) || ((this.transform.position.y - (this.transform.localScale.y * 2)) > CameraScreen.y || (this.transform.position.y + (this.transform.localScale.y * 2)) < -CameraScreen.y)) {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Time.timeScale > 0) {
            this.planet.GetComponent<Planet>().score += 1;
            GameObject.Find("God").GetComponent<God>().updateScore(this.planet.GetComponent<Planet>().score);
        }
    }
}
