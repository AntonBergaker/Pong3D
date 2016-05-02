using UnityEngine;
using System.Collections;

public class PaddleAI : PaddleInputParent {

    public BallBehavior ballVars;
    public Movement movementVars;
    public int smart;

	// Use this for initialization
    public override Vector2 GetInput()
    {
        float x = Mathf.Sign(ballVars.x - movementVars.body.position.x);
        float y = Mathf.Sign(ballVars.y - movementVars.body.position.y);


        return new Vector2(x,y);
    }
}
