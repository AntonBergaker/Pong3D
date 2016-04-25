using UnityEngine;
using System.Collections;

public class Ball_behavior : MonoBehaviour {

    public Transform body;
    public Transform paddle1;
    public Transform paddle2;
    public Transform upperBound;
    public Transform lowerBound;
    public Transform leftBound;
    public Transform rightBound;
    public Transform forwardBound;
    public Transform backBound;

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
    private float back;
    private float forward;
    private float paddleSize;
    private float ballSize;

	// Use this for initialization
	void Start () {
        //zSpeed = Mathf.Sign(Random.value * 2F - 1F) * 0.4F; //0.1F
        zSpeed = 1.5F;
        //ySpeed = Random.value * 0.1F;
        ySpeed = 0.7F;
        //xSpeed = Random.value * 0.1F;
        xSpeed = 1.0F;

        upper = upperBound.position.y;
        lower = lowerBound.position.y;
        left = leftBound.position.x;
        right = rightBound.position.x;
        back = backBound.position.z;
        forward = forwardBound.position.z;

        paddleSize = paddle1.localScale.x / 2F;
        ballSize = body.localScale.x / 2F;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        x += xSpeed;
        y += ySpeed;
        z += zSpeed;

        if (x+ballSize > right)
        {
            x = right-ballSize;
            xSpeed = -Mathf.Abs(xSpeed);
        }
        if (x-ballSize < left)
        {
            x = left + ballSize;
            xSpeed = Mathf.Abs(xSpeed);
        }
        if (y-ballSize < lower)
        {
            y = lower+ballSize;
            ySpeed = Mathf.Abs(ySpeed);
        }
        if (y+ballSize > upper)
        {
            y = upper-ballSize;
            ySpeed = -Mathf.Abs(ySpeed);
        }
        if (z - ballSize < forward)
        {
            z = forward + ballSize;
            zSpeed = Mathf.Abs(zSpeed);
        }
        if (z + ballSize > back)
        {
            z = back - ballSize;
            zSpeed = -Mathf.Abs(zSpeed);
        }

		if (Mathf.Abs(z - paddle1.position.z) < 2 + ballSize)
        {
			if (Mathf.Abs(x - paddle1.position.x) < paddleSize + ballSize)
            {
				if (Mathf.Abs(y - paddle1.position.y) < paddleSize + ballSize)
                {
                    zSpeed = -Mathf.Abs(zSpeed);
                }
            }
        }

        if (Mathf.Abs(z - paddle2.position.z) < 2 + ballSize)
        {
			if (Mathf.Abs(x - paddle2.position.x) < paddleSize + ballSize)
            {
				if (Mathf.Abs(y - paddle2.position.y) < paddleSize + ballSize)
                {
                    zSpeed = Mathf.Abs(zSpeed);
                }
            }
        }

        body.transform.position = new Vector3(x, y, z);
    }
}
