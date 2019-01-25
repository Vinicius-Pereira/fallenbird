using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    const string ACCELEROMETER = "Accelerometer";
    const string TOUCH = "Touch";
    
    [Range(1, 10)]
    public float movementVelocity = 10.0f;
    
    public GameObject gameOver;

    private string controlMode;
    private float screenCenterX;
    private bool touching = false;

	void Start () {
        screenCenterX = Screen.width * 0.5f;
	}

    private void FixedUpdate()
    {
        if(controlMode == ACCELEROMETER)
        {
            //refazer
            Vector3 acc = Input.acceleration;
            GetComponent<Rigidbody2D>().AddForce(new Vector3(acc.x * movementVelocity, 0, 0), ForceMode2D.Force);
        }
        else if(controlMode == TOUCH)
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
                    }
                    else if(touch.position.x < screenCenterX)
                    {
                        transform.Translate(Vector3.left * movementVelocity * Time.deltaTime);
                    }
                }
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * movementVelocity * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * movementVelocity * Time.deltaTime);
            }
        }
    }

    public void setControlMode()
    {
        controlMode = PlayerPrefs.GetString("Control");
        Debug.Log(controlMode);
    }
}
