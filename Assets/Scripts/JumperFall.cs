using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperFall : MonoBehaviour {

    //Velocidade de queda (scroll) do jumper
    private float fallVelocity;
    [Range(0, 1000)]
    public float energy;
    
    void FixedUpdate ()
    {
        //Identifica velocidade de queda e cai
        fallVelocity = Camera.main.GetComponent<ScrollEndless>().scrollSpeed;
        transform.Translate(Vector2.down * fallVelocity * Time.deltaTime);
	}

    //Tratamento de colisões com objetos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Quando colide com o player ativa ações do jumper e desetrói a si memso
        if(collision.CompareTag("Player"))
        {
            Debug.Log(energy);
            collision.GetComponent<Player>().increaseEnergy(energy);
            Camera.main.GetComponent<ScrollEndless>().ActiveJumperScrollSpeed();
            Destroy(gameObject);
        }
    }
}
