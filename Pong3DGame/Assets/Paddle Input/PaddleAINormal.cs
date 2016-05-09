using UnityEngine;
using System.Collections;

public class PaddleAINormal : PaddleInputParent {

    public BallBehavior ballVars;
    public Movement movementVars;

	// Use this for initialization
    public override Vector2 GetInput()
    {
        float x = Mathf.Clamp(ballVars.x - movementVars.body.position.x,-1,1) * 0.6F;
        float y = Mathf.Clamp(ballVars.y - movementVars.body.position.y,-1,1) * 0.6F;


        return new Vector2(x,y);
    }
}
