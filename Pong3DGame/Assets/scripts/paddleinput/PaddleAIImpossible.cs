using UnityEngine;
using System.Collections;

public class PaddleAIImpossible : PaddleInputParent
{
    public BallBehavior ballVars;
    public Movement movementVars;

    private float upper;
    private float lower;
    private float left;
    private float right;
    private float paddleSize;
    private float ballSize;

    // Use this for initialization
    void Start()
    {
        paddleSize = movementVars.body.localScale.x /2;
        ballSize = ballVars.body.localScale.x /2;

        upper   = ballVars.upperBound.position.y - ballSize;
        lower   = ballVars.lowerBound.position.y + ballSize;
        left    = ballVars.leftBound.position.x  + ballSize;
        right   = ballVars.rightBound.position.x - ballSize;
    }

    // Use this for initialization
    public override Vector2 GetInput()
    {
        float xBall = ballVars.x;
        float yBall = ballVars.y;
        float zBall = ballVars.z;
        float xPaddle = movementVars.body.position.x;
        float yPaddle = movementVars.body.position.y;
        float zPaddle = movementVars.body.position.z;
        float xSpeed = ballVars.xSpeed;
        float ySpeed = ballVars.ySpeed;
        float zSpeed = ballVars.zSpeed;
        float targetX, targetY;

        Debug.Log("speed " + zSpeed);
        Debug.Log("paddle" + zPaddle);

        if (Mathf.Sign(zSpeed) != Mathf.Sign(zPaddle)) //if going towards the player just head towards the center
        {
            targetX = 0;
            targetY = 0;
        }
        else if (Mathf.Abs(zBall) > Mathf.Abs(zPaddle)) //if he missed
        { 
            targetX = 0;
            targetY = 0;
        }
        else
        {
            //cleanup input
            if (xSpeed == 0)
            {xSpeed = Mathf.Epsilon;}
            if (ySpeed == 0)
            { ySpeed = Mathf.Epsilon; }

            for (int i = 0; i < 1000; i++) //only handle 1000 bounces, because lag
            {
                //find out how far until it hits a wall and which one
                float xTime, yTime,zTime;
                if (xSpeed > 0)
                { xTime = Mathf.Abs((xBall - upper) / xSpeed); }
                else
                { xTime = Mathf.Abs((xBall - lower) / xSpeed); }
                if (ySpeed > 0)
                { yTime = Mathf.Abs((yBall - right) / ySpeed); }
                else
                { yTime = Mathf.Abs((yBall - left) / ySpeed); }
                zTime = Mathf.Abs((zBall - zPaddle) / zSpeed);

                Vector3 before = new Vector3(xBall, yBall, zBall);

                if (xTime < yTime && xTime < zTime) //if x is smallest
                {
                    zBall = zBall + zSpeed * xTime;
                    xBall = xBall + xSpeed * xTime;
                    yBall = yBall + ySpeed * xTime;
                    xSpeed *= -1;
                }
                else if (yTime < zTime) //if y is smallest
                {
                    zBall = zBall + zSpeed * yTime;
                    xBall = xBall + xSpeed * yTime;
                    yBall = yBall + ySpeed * yTime;
                    ySpeed *= -1;
                }
                else //if z is smallest
                {
                    zBall = zPaddle;
                    xBall = xBall + xSpeed * zTime;
                    yBall = yBall + ySpeed * zTime;
                    Debug.DrawLine(before, new Vector3(xBall, yBall, zBall));
                    break;    
                }

                Debug.DrawLine(before, new Vector3(xBall, yBall, zBall));
            }

            targetY = yBall +paddleSize;
            targetX = xBall +paddleSize;
        }


        float x = Mathf.Clamp(targetX - xPaddle,-1,1);
        float y = Mathf.Clamp(targetY - yPaddle,-1,1);

        return new Vector2(x, y);
    }

}
