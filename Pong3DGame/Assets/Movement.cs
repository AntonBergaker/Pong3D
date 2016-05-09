using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public Transform body;

    public Transform upperBound;
    public Transform lowerBound;
    public Transform leftBound;
    public Transform rightBound;
    public Renderer cubeRenderer;

    public PaddleInputParent inputScript;

    public float bound;

    public float speed;
    public float acceleration;
    private float x;
    private float y;
    private float z;
    private float xSpeed;
    private float ySpeed;
    private float bounceTimer;
    private float paddleSize;

	// Use this for initialization
	void Start () {
        x = body.transform.position.x;
        y = body.transform.position.y;
        z = body.transform.position.z;
        paddleSize = body.localScale.x / 2F;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 input = inputScript.GetInput();

        float moveX = input.x;
        float moveY = input.y;

        xSpeed = Mathf.MoveTowards(xSpeed, 0, acceleration * Time.deltaTime);
        ySpeed = Mathf.MoveTowards(ySpeed, 0, acceleration * Time.deltaTime);
        xSpeed = Mathf.Clamp(xSpeed + moveX * Time.deltaTime * acceleration * 2,-speed,speed);
        ySpeed = Mathf.Clamp(ySpeed + moveY * Time.deltaTime * acceleration * 2,-speed,speed);

        x += xSpeed;
        y += ySpeed;

        x = Mathf.Clamp(x, -bound, bound);
        y = Mathf.Clamp(y, -bound, bound);

        body.transform.position = new Vector3(x, y, z);

        //increase the size slightly when bouncing
        if (bounceTimer > 0)
        {
            body.localScale = new Vector3(paddleSize*2 + bounceTimer,paddleSize*2 + bounceTimer,1);
            bounceTimer -= Time.deltaTime;
        }
	}

    public void Bounce()
    {
        bounceTimer = 2F;
    }
}
