using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [Range(0,10)]
    public float timeInitialJump = 0.0f;

    private float originalTimeInitialJump;

    private float timeJump;

    private float originalTimeJump;

    private bool finishedInitialJump;
    private bool finishedJump;

    private bool jumpMovement = false;

	// Use this for initialization
	void Start () {
        //Inicia animação de disparo do pássaro
        GetComponent<Animator>().SetBool("start", true);
        // Backup do tempo inicial de pulo
        originalTimeInitialJump = timeInitialJump;
        // Tempo de impulso do pulo no ar é sempre 10% do tempo de scroll
        timeJump = GetComponent<ScrollEndless>().timeJumperScrollSpeed * 0.1f;
        // Backup do tempo do impulso do pulo
        originalTimeJump = timeJump;
    }

	void Update () {
        finishedInitialJump = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TopInitialJump") ? true : false;
        if (timeInitialJump <= 0 && !GetComponent<Animator>().GetBool("startFall"))
        {
            GetComponent<Animator>().SetBool("startFall", true);
            timeInitialJump = originalTimeInitialJump;
        }
        else if (finishedInitialJump)
        {
            timeInitialJump -= Time.deltaTime;
        }

        finishedJump = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TopJump") ? true : false;
        if (timeJump <= 0 && !GetComponent<Animator>().GetBool("startFall"))
        {
            GetComponent<Animator>().SetBool("startFall", true);
            timeJump = originalTimeJump;
        }
        else if (finishedJump)
        {
            timeJump -= Time.deltaTime;
        }

    }

    public void ActiveJumpMovement()
    {
        if(!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FallInitialJump"))
        {
            var count = GetComponent<Animator>().GetInteger("jumpCount");
            GetComponent<Animator>().SetInteger("jumpCount", ++count);
            GetComponent<Animator>().SetBool("jump", true);
        }
    }

    public void ResetMovements()
    {
        GetComponent<Animator>().SetBool("jump", false);
        GetComponent<Animator>().SetBool("startFall", false);
    }

    public void DecreaseJump()
    {
        var count = GetComponent<Animator>().GetInteger("jumpCount");
        if(count <= 1)
        {
            GetComponent<Animator>().SetInteger("jumpCount", 0);
        }
        else
        {
            GetComponent<Animator>().SetInteger("jumpCount", --count);
        }
    }

}
