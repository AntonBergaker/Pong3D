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
    public AudioClip[] bounceSounds;
    public AudioClip paddleSound;

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

    public bool active;

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
        zSpeed = Choose(new float[] {-1,1});
        ySpeed = Random.Range(-0.5F,0.5F);
        xSpeed = Random.Range(-0.5F,0.5F);

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
        if (active)
        {
            x += xSpeed;
            y += ySpeed;
            z += zSpeed;

            if (x+ballSize > right)
            {
                x = right-ballSize;
                xSpeed = -Mathf.Abs(xSpeed);
                BounceSound(); //play sound when bouncing
            }
            if (x-ballSize < left)
            {
                x = left + ballSize;
                xSpeed = Mathf.Abs(xSpeed);
                BounceSound();
            }
            if (y-ballSize < lower)
            {
                y = lower+ballSize;
                ySpeed = Mathf.Abs(ySpeed);
                BounceSound();
            }
            if (y+ballSize > upper)
            {
                y = upper-ballSize;
                ySpeed = -Mathf.Abs(ySpeed);
                BounceSound();
            }
            if (z - ballSize < forward)
            {
                z = forward + ballSize;
                zSpeed = Mathf.Abs(zSpeed);
                BounceSound();
            }
            if (z + ballSize > back)
            {
                z = back - ballSize;
                zSpeed = -Mathf.Abs(zSpeed);
                BounceSound();
            }

            if (zSpeed > 0)
            {
                if (Mathf.Abs(z - bodyPlayer1.position.z) < Mathf.Abs(zSpeed) + ballSize) //compare with speed to make sure it always catches the bounce
                {
                    if (Mathf.Abs(x - bodyPlayer1.position.x) < paddleSize + ballSize)
                    {
                        if (Mathf.Abs(y - bodyPlayer1.position.y) < paddleSize + ballSize)
                        {
                            zSpeed = -Mathf.Abs(zSpeed);
                            xSpeed = (x - bodyPlayer1.position.x) * -zSpeed / 5;
                            ySpeed = (y - bodyPlayer1.position.y) * -zSpeed / 5;
                            AudioSource.PlayClipAtPoint(paddleSound, body.transform.position);
                            varsPlayer1.Bounce(); //do particle effects at the paddle
                        }
                    }
                }
            }

            if (zSpeed < 0)
            {
                if (Mathf.Abs(z - bodyPlayer2.position.z) < Mathf.Abs(zSpeed) + ballSize) //compare with speed to make sure it always catches the bounce
                {
                    if (Mathf.Abs(x - bodyPlayer2.position.x) < paddleSize + ballSize)
                    {
                        if (Mathf.Abs(y - bodyPlayer2.position.y) < paddleSize + ballSize)
                        {
                            zSpeed = Mathf.Abs(zSpeed);
                            xSpeed = (x - bodyPlayer2.position.x) * zSpeed / 5;
                            ySpeed = (y - bodyPlayer2.position.y) * zSpeed / 5;
                            AudioSource.PlayClipAtPoint(paddleSound, body.transform.position);
                            varsPlayer2.Bounce();
                        }
                    }
                }
            }

            body.transform.position = new Vector3(x, y, z);
        }
    }

    float Choose(params float[] s)
    {
        return s[Random.Range(0,s.Length)];
    }

    void BounceSound()
        { AudioSource.PlayClipAtPoint(bounceSounds[Random.Range(0, bounceSounds.Length - 1)], body.transform.position);} //choose random sound effect from array
    }
