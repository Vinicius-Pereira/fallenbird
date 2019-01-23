using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperFall : MonoBehaviour {

    public GameObject player;
	
	// Update is called once per frame
	void FixedUpdate () {
        var velocity = player.GetComponent<Rigidbody2D>().velocity.y;
        transform.Translate(Vector2.down * velocity * Time.deltaTime);
	}
}
