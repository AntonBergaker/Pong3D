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

	// Use this for initialization
	void Start () {
        zSpeed = Mathf.Sign(Random.value * 2F - 1F);
        ySpeed = Random.value;
        xSpeed = Random.value;

        upper = upperBound.position.y;
        lower = lowerBound.position.y;
        left = leftBound.position.x;
        right = rightBound.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        x += xSpeed;
        y += ySpeed;
        z += zSpeed;

        if (x > right)
        {
            x = right;
            xSpeed = -Mathf.Abs(xSpeed);
        }
        if (x < left)
        {
            x = left;
            xSpeed = Mathf.Abs(xSpeed);
        }
        if (y < lower)
        {
            y = lower;
            ySpeed = Mathf.Abs(ySpeed);
        }
        if (y > upper)
        {
            y = upper;
            ySpeed = -Mathf.Abs(ySpeed);
        }
        if (z > 60)
        {
            z = 60;
            zSpeed = -1;
        }
        if (z < -60)
        {
            z = -60;
            zSpeed = 1;
        }

        body.transform.position = new Vector3(x, y, z);
	}
}
