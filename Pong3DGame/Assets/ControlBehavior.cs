using UnityEngine;
using System.Collections;

public class ControlBehavior : MonoBehaviour {

    public GameObject ball;
    public float ballStartSpeed;
    public float ballSecondIncrease;

    private BallBehavior ballVars;
    private float ballTimer = 0;

	// Use this for initialization
	void Start () {
        ballVars = ball.GetComponent<BallBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
        ballTimer+=Time.deltaTime;
	    if (ballVars.z > 70)
        {
            ballVars.z = 0;
            ballVars.x = 0;
            ballVars.y = 0;
            ballVars.zSpeed = -1;
            ballTimer = 0;
        }
        if (ballVars.z < -70)
        {
            ballVars.z = 0;
            ballVars.x = 0;
            ballVars.y = 0;
            ballVars.zSpeed = 1;
            ballTimer = 0;
        }

        ballVars.zSpeed = Mathf.Sign(ballVars.zSpeed) * (ballStartSpeed + ballTimer * ballSecondIncrease);
	}
}
