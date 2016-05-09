using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {

    public Transform body;
    public GameObject paddlePlayer1;
    public GameObject paddlePlayer2;
    public Transform upperBound;
    public Transform lowerBound;
    public Transform leftBound;
    public Transform rightBound;
    public Transform forwardBound;
    public Transform backBound;

    [HideInInspector]
    public float xSpeed;
    [HideInInspector]
    public float ySpeed;
    [HideInInspector]
    public float zSpeed;
    [HideInInspector]
    public float x;
    [HideInInspector]
    public float y;
    [HideInInspector]
    public float z;

    private Transform bodyPlayer1;
    private Transform bodyPlayer2;
    private Movement varsPlayer1;
    private Movement varsPlayer2;

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
        zSpeed = 0.5F;
        ySpeed = 0.0F;
        xSpeed = 0.0F;

        upper = upperBound.position.y;
        lower = lowerBound.position.y;
        left = leftBound.position.x;
        right = rightBound.position.x;
        back = backBound.position.z;
        forward = forwardBound.position.z;

        bodyPlayer1 = paddlePlayer1.GetComponent<Transform>();
        bodyPlayer2 = paddlePlayer2.GetComponent<Transform>();
        varsPlayer1 = paddlePlayer1.GetComponent<Movement>();
        varsPlayer2 = paddlePlayer2.GetComponent<Movement>();
        paddleSize = bodyPlayer1.localScale.x / 2F;
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

        if (Mathf.Abs(z - bodyPlayer1.position.z) < Mathf.Abs(zSpeed) + ballSize) //compare with speed to make sure it always catches the bounce
        {
            if (Mathf.Abs(x - bodyPlayer1.position.x) < paddleSize + ballSize)
            {
                if (Mathf.Abs(y - bodyPlayer1.position.y) < paddleSize + ballSize)
                {
                    zSpeed = -Mathf.Abs(zSpeed);
                    xSpeed = (x - bodyPlayer1.position.x) * -zSpeed / 5;
                    ySpeed = (y - bodyPlayer1.position.y) * -zSpeed / 5;
                    varsPlayer1.Bounce(); //do particle effects at the paddle
                }
            }
        }

        if (Mathf.Abs(z - bodyPlayer2.position.z) < Mathf.Abs(zSpeed) + ballSize) //compare with speed to make sure it always catches the bounce
        {
            if (Mathf.Abs(x - bodyPlayer2.position.x) < paddleSize + ballSize)
            {
                if (Mathf.Abs(y - bodyPlayer2.position.y) < paddleSize + ballSize)
                {
                    zSpeed = Mathf.Abs(zSpeed);
                    xSpeed = (x - bodyPlayer2.position.x) * zSpeed / 5;
                    ySpeed = (y - bodyPlayer2.position.y) * zSpeed / 5;
                    varsPlayer2.Bounce();
                }
            }
        }

        body.transform.position = new Vector3(x, y, z);
    }
}
