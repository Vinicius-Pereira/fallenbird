using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    const string ACCELEROMETER = "Accelerometer";
    const string TOUCH = "Touch";

    [Range(1,10)]
    public float jumpVelocity = 10.0f;

    [Range(1, 10)]
    public float movementVelocity = 10.0f;

    public GameObject gameOver;

    private string controlMode;
    private float screenCenterX;
    private bool touching = false;

	void Start () {
        screenCenterX = Screen.width * 0.5f;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
	}

    private void Update()
    {
        Debug.Log(GetComponent<Rigidbody2D>().velocity.y);
    }

    private void FixedUpdate()
    {
        if(controlMode == ACCELEROMETER)
        {
            Vector3 acc = Input.acceleration;
            GetComponent<Rigidbody2D>().AddForce(new Vector3(acc.x * movementVelocity, 0, 0), ForceMode2D.Force);
        }
        else
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch(touch.phase)
                {
                    case TouchPhase.Began:
                        touching = true;
                        break;
                    case TouchPhase.Moved:
                        touching = true;
                        break;
                    case TouchPhase.Ended:
                        touching = false;
                        break;
                }
                if (touching)
                {
                    if(touch.position.x > screenCenterX)
                    {
                        transform.Translate(Vector3.right * movementVelocity * Time.deltaTime);
                        //GetComponent<Rigidbody2D>().AddForce(new Vector3(movementVelocity * Time.deltaTime, 0, 0), ForceMode2D.Force);  
                    }
                    else if(touch.position.x < screenCenterX)
                    {
                        transform.Translate(Vector3.left * movementVelocity * Time.deltaTime);
                        //GetComponent<Rigidbody2D>().AddForce(new Vector3(movementVelocity * Time.deltaTime * -1, 0, 0), ForceMode2D.Force);
                    }
                }
            }
            
        }
    }

    public void setControlMode()
    {
        controlMode = PlayerPrefs.GetString("Control");
        Debug.Log(controlMode);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("dead"))
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
