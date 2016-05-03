using UnityEngine;
using System.Collections;

public class ControlBehavior : MonoBehaviour {

    public GameObject ball;
    public float ballStartSpeed;
    public float ballSecondIncrease;

    public int player1Score = 0;
    public int player2Score = 0;

    public GUIStyle scoreFont;

    private BallBehavior ballVars;
    private float ballTimer = 0;

	// Use this for initialization
	void Start () {
        ballVars = ball.GetComponent<BallBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
        ballTimer+=Time.deltaTime;
        if (Mathf.Abs(ballVars.z) > 80) //if the ball is outside the playfield
        {
            if (ballVars.z > 0 && ballVars.zSpeed > 0) //give players points
            {
				ballVars.zSpeed = -ballStartSpeed;
                player1Score++;
            }
            else if (ballVars.z < 0 && ballVars.zSpeed < 0)
            {
				ballVars.zSpeed = ballStartSpeed;
                player2Score++;
            }
            //ballVars.z = 0; //reset the ball position and speed
            //ballVars.x = 0;
            //ballVars.y = 0;
            ballVars.xSpeed = Random.Range(-0.2F, 0.2F);
            ballVars.ySpeed = Random.Range(-0.2F, 0.2F);
            ballTimer = 0;
        }

        ballVars.zSpeed = Mathf.Sign(ballVars.zSpeed) * (ballStartSpeed + ballTimer * ballSecondIncrease); //set the ball speed after the timer
	}

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 1920F, Screen.height / 1080F, 1));


        GUI.Label(new Rect(960, 90, 1, 1), "-", scoreFont);
        GUI.Label(new Rect(960 - 80, 90, 1, 1), player1Score.ToString(), scoreFont);
        GUI.Label(new Rect(960 + 80, 90, 1, 1), player2Score.ToString(), scoreFont);
    }
}
