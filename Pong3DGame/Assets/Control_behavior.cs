using UnityEngine;
using System.Collections;

public class Control_behavior : MonoBehaviour {

    public GameObject ball;
    public float ballStartSpeed;
    public float ballSecondIncrease;

    private Ball_behavior ballVars;
    private float timer = 0;

	// Use this for initialization
	void Start () {
        ballVars = ball.GetComponent<Ball_behavior>();
	}
	
	// Update is called once per frame
	void Update () {
        timer+=Time.deltaTime;
	    if (ballVars.z > 70)
        {
            ballVars.z = 0;
            ballVars.x = 0;
            ballVars.y = 0;
            ballVars.zSpeed = -2;
        }
        if (ballVars.z < -70)
        {
            ballVars.z = 0;
            ballVars.x = 0;
            ballVars.y = 0;
            ballVars.zSpeed = 2;
        }

        ballVars.zSpeed = Mathf.Sign(ballVars.zSpeed) * (ballStartSpeed + timer * ballSecondIncrease);
	}
}
