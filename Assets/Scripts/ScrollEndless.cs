using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollEndless : MonoBehaviour {

    //Velocidade padrão do scroll
    [Range(0, 10)]
    public float scrollSpeed = 0.0f;
    //Velocidade do scroll quando o player pula em um dos jumpers
    [Range(0, 10)]
    public float jumperScrollSpeed = 0.0f;
    //Tempo que dura o impulso do jumper
    [Range(0, 10)]
    public float timeJumperScrollSpeed = 0.0f;

    public GameObject player;

    private float originalScrollSpeed;
    private float timeBoostVelocity;

    private void Awake()
    {
        //Faz backup de velocidades base
        originalScrollSpeed = scrollSpeed;
        timeBoostVelocity = timeJumperScrollSpeed;
    }

    private void Update()
    {
        //Atualiza velocidade de scroll para os itens
        if (scrollSpeed == jumperScrollSpeed)
        {
            timeBoostVelocity -= Time.deltaTime;
            if (timeBoostVelocity <= 0)
            {
                scrollSpeed = originalScrollSpeed;
                timeBoostVelocity = timeJumperScrollSpeed;
            }
        }
    }

    //Ativa velocidade de pulo do scroll
    public void ActiveJumperScrollSpeed()
    {
        scrollSpeed = jumperScrollSpeed;
        timeBoostVelocity = timeJumperScrollSpeed;
        GetComponent<CameraMovement>().ActiveJumpMovement();
    }


}
