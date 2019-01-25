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
        //Verifica se a animação de pulo inicial já chegou em seu zênite
        finishedInitialJump = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TopInitialJump") ? true : false;
        //Caso tenha chego e o tempo de zênite esteja zerado, inicia animação de queda 
        if (timeInitialJump <= 0 && !GetComponent<Animator>().GetBool("startFall"))
        {
            GetComponent<Animator>().SetBool("startFall", true);
            timeInitialJump = originalTimeInitialJump;
        }
        //Caso tenha chego e o tempo não esteja concluído ainda, reduz o tempo
        else if (finishedInitialJump)
        {
            timeInitialJump -= Time.deltaTime;
        }
        //Verifica se a animação de pulo padrão já chegou em seu zênite
        finishedJump = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TopJump") ? true : false;
        //Caso tenha chego e o tempo de zênite esteja zerado, inicia animação de queda
        if (timeJump <= 0 && !GetComponent<Animator>().GetBool("startFall"))
        {
            GetComponent<Animator>().SetBool("startFall", true);
            timeJump = originalTimeJump;
        }
        //Caso tenha chego e o tempo não esteja concluído ainda, reduz o tempo
        else if (finishedJump)
        {
            timeJump -= Time.deltaTime;
        }

    }

    //Ativa animação de pulo padrão
    public void ActiveJumpMovement()
    {
        if(!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FallInitialJump"))
        {
            //Contador de pulos multiplos
            var count = GetComponent<Animator>().GetInteger("jumpCount");
            GetComponent<Animator>().SetInteger("jumpCount", ++count);
            //Ativa animação de pulo
            GetComponent<Animator>().SetBool("jump", true);
        }
    }

    //Reseta variáveis de animação
    public void ResetMovements()
    {
        GetComponent<Animator>().SetBool("jump", false);
        GetComponent<Animator>().SetBool("startFall", false);
    }

    //Reduz a quantidade de pulos por ciclo de animação
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
