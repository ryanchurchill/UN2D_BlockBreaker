﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    // properties initialized
    Vector2 paddleToBallVector;

    // state
    bool hasStarted = false;

    // cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        //Debug.Log(transform.position.ToString());
    }

    void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            //TODO: turn off ticking?
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted && ballSounds.Length > 0)
        {
            // TODO: trim the beginning of these sounds
            myAudioSource.PlayOneShot(ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]);
        }
    }
}
