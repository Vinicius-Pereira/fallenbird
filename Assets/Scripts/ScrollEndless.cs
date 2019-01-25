using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollEndless : MonoBehaviour {

    [Range(1, 10)]
    public float initialVelocity = 1.0f;

    [Range(1, 10)]
    public float velocity = 1.0f;

    public GameObject player;

	// Use this for initialization
	void Start () {
        transform.Translate(Vector2.down * initialVelocity * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
