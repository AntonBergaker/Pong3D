﻿using UnityEngine;
using System.Collections;

public class PaddleAI : PaddleInputParent {

    public BallBehavior ballVars;
    public Movement movementVars;
    public int smart;

	// Use this for initialization
    public override Vector2 GetInput()
    {
        float x = Mathf.Clamp(ballVars.x - movementVars.body.position.x,-1,1);
        float y = Mathf.Clamp(ballVars.y - movementVars.body.position.y,-1,1);


        return new Vector2(x,y);
    }
}
