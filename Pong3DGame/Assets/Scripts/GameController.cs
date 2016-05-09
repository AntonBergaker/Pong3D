using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject ball;
	public GameObject explosion;
    public float ballStartSpeed;
    public float ballSecondIncrease;

    public int player1Score = 0;
    public int player2Score = 0;
	public int scoreWin = 1;

	public string screenMessage;

    public GUIStyle scoreFont;

	private BallBehavior ballVars;
    private float ballTimer = 0;
	private float ballRange = 100;

	// Use this for initialization
	void Start () {
        ballVars = ball.GetComponent<BallBehavior>();
		screenMessage = "";
	}
	
	// Update is called once per frame
	void Update () {
        ballTimer+=Time.deltaTime;
        if (Mathf.Abs(ballVars.z) > ballRange) //if the ball is outside the playfield
        {
            if (ballVars.z > 0 && ballVars.zSpeed > 0) //give players points
            {
				ballVars.zSpeed = -ballStartSpeed;
                player2Score++;
				Explode ();
            }
            else if (ballVars.z < 0 && ballVars.zSpeed < 0)
            {
				ballVars.zSpeed = ballStartSpeed;
                player1Score++;
				Explode ();
            }

			if (player1Score >= scoreWin)
			{
				screenMessage = "You have won!";
				ResetScores ();
			}

			if (player2Score >= scoreWin)
			{
				screenMessage = "You have lost!";
				ResetScores ();
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
		GUI.Label(new Rect(550, 400, 1, 1), screenMessage, scoreFont);
    }

	void Explode()
	{
		ballVars.xSpeed = 0;
		ballVars.ySpeed = 0;
		ballVars.zSpeed = 0;
		/*bool animating = true;
		float start = Time.realtimeSinceStartup;
		float end = start + 5.0F;
		if (animating) {
			if (end < Time.realtimeSinceStartup) {
				animating = false;
			}
		}*/
		Instantiate(explosion, new Vector3(ballVars.x, ballVars.y, ballVars.z), new Quaternion(0, 0, 0, 0));
	}

	void ResetScores()
	{
		player1Score = 0;
		player2Score = 0;
	}
}
