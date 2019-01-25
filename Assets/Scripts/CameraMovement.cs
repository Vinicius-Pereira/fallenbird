using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [Range(0,10)]
    public float timeInitialJump = 0.0f;

    private bool finishedInitialJump;

    private bool jumpMovement = false;

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().SetBool("start", true);
	}
	
	// Update is called once per frame
	void Update () {
        finishedInitialJump = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TopInitialJump") ? true : false;
        if (timeInitialJump <= 0 && !GetComponent<Animator>().GetBool("startFall"))
        {
            GetComponent<Animator>().SetBool("startFall", true);
        }else if (finishedInitialJump)
        {
            timeInitialJump -= Time.deltaTime;
        }

        if(jumpMovement)
        {
            Vector3 destination = new Vector3(transform.position.x, transform.position.y - 5);
            transform.position = Vector3.Lerp(transform.position, destination, 100 * Time.deltaTime);
            Debug.Log("current:" + transform.position.y + "  destination:" + destination.y);
        }
	}

    public void ActiveJumpMovement()
    {
        jumpMovement = true;
    }
}
