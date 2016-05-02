using UnityEngine;
using System.Collections;

public class PaddleAiDifficulty2 : PaddleInputParent {

    public BallBehavior ballVars;
    public Movement movementVars;

	// Use this for initialization
    public override Vector2 GetInput()
    {
        float x = Mathf.Sign(ballVars.x - movementVars.body.position.x) * 0.6F;
        float y = Mathf.Sign(ballVars.y - movementVars.body.position.y) * 0.6F;


        return new Vector2(x,y);
    }
}
