using UnityEngine;
using System.Collections;

public class ControlBehavior : MonoBehaviour {

    public GameObject ball;
    public float ballStartSpeed;
    public float ballSecondIncrease;

    public int player1Score;
    public int player2Score;

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
        if (Mathf.Abs(ballVars.z) > 70)
        {
            ballVars.z = 0;
            ballVars.x = 0;
            ballVars.y = 0;
			ballVars.xSpeed = 0.0F;
			ballVars.ySpeed = 0.0F;
			ballVars.zSpeed = 0.0F;
            ballTimer = 0;

            if (ballVars.z > 70)
            {
				ballVars.zSpeed = -ballStartSpeed;
            }
            if (ballVars.z < -70)
            {
				ballVars.zSpeed = ballStartSpeed;
            }
        }

        ballVars.zSpeed = Mathf.Sign(ballVars.zSpeed) * (ballStartSpeed + ballTimer * ballSecondIncrease);
	}

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 1920.0f, Screen.height / 1080.0f, 1));


        GUI.Label(new Rect(960, 30, 1, 1), "-", scoreFont);
        GUI.Label(new Rect(960 - 80, 30, 1, 1), player1Score.ToString(), scoreFont);
        GUI.Label(new Rect(960 + 80, 30, 1, 1), player2Score.ToString(), scoreFont);
    }
}
