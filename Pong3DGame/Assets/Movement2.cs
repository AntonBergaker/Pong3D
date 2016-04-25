﻿using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour {

    public Transform body;

    public Transform upperBound;
    public Transform lowerBound;
    public Transform leftBound;
    public Transform rightBound;

    public Transform ball;

    public float bound;

    public float speed;
    public float acceleration;
    private float x;
    private float y;
    private float z;
    private float xSpeed;
    private float ySpeed;

	// Use this for initialization
	void Start () {
        x = body.transform.position.x;
        y = body.transform.position.y;
        z = body.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        /*float moveX =-Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        xSpeed = Mathf.MoveTowards(xSpeed, 0, acceleration * Time.deltaTime);
        ySpeed = Mathf.MoveTowards(ySpeed, 0, acceleration * Time.deltaTime);
        xSpeed = Mathf.Clamp(xSpeed + moveX * Time.deltaTime * acceleration * 2,-speed,speed);
        ySpeed = Mathf.Clamp(ySpeed + moveY * Time.deltaTime * acceleration * 2,-speed,speed);

        x += xSpeed;
        y += ySpeed;

        x = Mathf.Clamp(x, -bound, bound);
        y = Mathf.Clamp(y, -bound, bound);*/

        x = ball.transform.position.x;
        y = ball.transform.position.y;

        body.transform.position = new Vector3(x, y, z);
	}
}