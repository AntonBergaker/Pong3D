using UnityEngine;
using System.Collections;

public class Ball_behavior : MonoBehaviour {

    public Transform body;
    public Transform paddle;
    public Transform upperBound;
    public Transform lowerBound;
    public Transform leftBound;
    public Transform rightBound;

    private float xSpeed;
    private float ySpeed;
    private float zSpeed;
    private float x;
    private float y;
    private float z;
    private float upper;
    private float lower;
    private float left;
    private float right;
    private float paddleSize;
    private float ballSize;

	// Use this for initialization
	void Start () {
        zSpeed = Mathf.Sign(Random.value * 2F - 1F) * 0.1F;
        ySpeed = Random.value * 0.1F;
        xSpeed = Random.value * 0.1F;

        upper = upperBound.position.y;
        lower = lowerBound.position.y;
        left = leftBound.position.x;
        right = rightBound.position.x;

        paddleSize = paddle.localScale.x / 2F;
        ballSize = body.localScale.x / 2F;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        x += xSpeed;
        y += ySpeed;
        z += zSpeed;

        if (x+ballSize > right)
        {
            x = right+ballSize;
            xSpeed = -Mathf.Abs(xSpeed);
        }
        if (x-ballSize < left)
        {
            x = left + ballSize;
            xSpeed = Mathf.Abs(xSpeed);
        }
        if (y+ballSize < lower)
        {
            y = lower+ballSize;
            ySpeed = Mathf.Abs(ySpeed);
        }
        if (y-ballSize > upper)
        {
            y = upper-ballSize;
            ySpeed = -Mathf.Abs(ySpeed);
        }


        if (z > paddle.position.z)
        {
            if (x > paddle.position.x - paddleSize && x < paddle.position.x + paddleSize)
            {
                if (y > paddle.position.y - paddleSize && y < paddle.position.y + paddleSize)
                {
                    Debug.Log("BOUNCE");
                    zSpeed = -0.1F;
                }
            }
        }

        //backup bounce
        if (z > 60)
        {
            z = 60;
            zSpeed = -0.1F;
        }
        if (z < -60)
        {
            z = -60;
            zSpeed = 0.1F;
        }

        body.transform.position = new Vector3(x, y, z);
	}
}
