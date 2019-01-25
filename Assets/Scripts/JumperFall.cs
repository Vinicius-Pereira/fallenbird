using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperFall : MonoBehaviour {

    [Range(1,10)]
    public float fallVelocity = 1.0f;

    [Range(1, 10)]
    public float bounceVelocity = 1.0f;

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(Vector2.down * fallVelocity * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Player"))
        //{

        //    GetComponent<Rigidbody2D>().velocity = Vector2.down * bounceVelocity;

        //    Destroy(this.gameObject);

        //}

        if (other.CompareTag("dead"))
        {
            Destroy(this.gameObject);
        }
    }
}
