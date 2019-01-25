using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollEndless : MonoBehaviour {

    [Range(0, 10)]
    public float scrollSpeed = 0.0f;
    [Range(0, 10)]
    public float jumperScrollSpeed = 0.0f;
    [Range(0, 10)]
    public float timeJumperScrollSpeed = 0.0f;

    public GameObject player;

    private float originalScrollSpeed;
    private float timeBoostVelocity;

    private void Awake()
    {
        originalScrollSpeed = scrollSpeed;
        timeBoostVelocity = timeJumperScrollSpeed;
    }

    private void Update()
    {
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

    public void ActiveJumperScrollSpeed()
    {
        scrollSpeed = jumperScrollSpeed;
        timeBoostVelocity = timeJumperScrollSpeed;
        GetComponent<CameraMovement>().ActiveJumpMovement();
    }


}
