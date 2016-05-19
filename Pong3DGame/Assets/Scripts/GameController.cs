using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject ball;
	public GameObject explosion;
    public GameObject confetti;
    public AudioSource explosionSound;
    public float ballStartSpeed;
    public float ballSecondIncrease;


    [HideInInspector]
    public int player1Score = 0;
    [HideInInspector]
    public int player2Score = 0;
    [HideInInspector]
    public bool freezeBall = false;

    public int scoreToWin;
    public int leadToWin;

	public string screenMessage;

    public GUIStyle scoreFont;

	private BallBehavior ballVars;
    private float ballTimer = 0;
	private float ballBound = 80;

    private Menu menu;

	// Use this for initialization
	void Start () {
        ballVars = ball.GetComponent<BallBehavior>();
        menu = GetComponent<Menu>();
		screenMessage = "";
	}
	
	// Update is called once per frame
	void Update () {
        ballTimer+=Time.deltaTime;
        if (Mathf.Abs(ballVars.z) > ballBound) //if the ball is outside the playfield
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

			if (player1Score >= scoreToWin && player1Score >= player2Score+leadToWin)
			{
				screenMessage = "You have won!";
				ResetScores ();
			}

			if (player2Score >= scoreToWin && player2Score >= player1Score+leadToWin)
			{
				screenMessage = "You have lost!";
				ResetScores ();
			}


            ballVars.xSpeed = Random.Range(-0.2F, 0.2F);
            ballVars.ySpeed = Random.Range(-0.2F, 0.2F);
            ballTimer = 0;
        }

        if (freezeBall) //stop the ball from moving if frozen
        { 
            ballVars.z = 0;
            ballTimer = 0F;
        }

        ballVars.zSpeed = Mathf.Sign(ballVars.zSpeed) * (ballStartSpeed + ballTimer * ballSecondIncrease); //set the ball speed after the timer

        //if paused
        if (Input.GetKeyDown("escape"))
        {
            menu.active = true;
            freezeBall = true;
        }
	}

    void OnGUI()
    {
        scoreFont.fontSize = Screen.width / 20;
        int screenHalf = Screen.width / 2;
        int drawHeight = scoreFont.fontSize/2 + 4 + Screen.height / 25;

        GUI.Label(new Rect(screenHalf, drawHeight, 1, 1), player1Score.ToString() +  " - " + player2Score.ToString(), scoreFont);
    }

	void Explode()
	{
        explosionSound.Play();
		GameObject temp = (GameObject)Instantiate(explosion, new Vector3(ballVars.x, ballVars.y, ballVars.z), new Quaternion(0, 0, 0, 0));
        Destroy(temp, 3F); //destroy it after 3 seconds when it's done playing
        temp = (GameObject)Instantiate(confetti, new Vector3(ballVars.x, ballVars.y, ballVars.z), new Quaternion(0, 0, 0, 0));
        Destroy(temp, 5F); //destroy it after 3 seconds when it's done playing
	}

	void ResetScores()
	{
		player1Score = 0;
		player2Score = 0;
	}
}
