using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperFall : MonoBehaviour {


    private float fallVelocity;
    
    void FixedUpdate ()
    {
        fallVelocity = Camera.main.GetComponent<ScrollEndless>().scrollSpeed;
        transform.Translate(Vector2.down * fallVelocity * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Camera.main.GetComponent<ScrollEndless>().ActiveJumperScrollSpeed();
            Destroy(gameObject);
        }
    }
}
