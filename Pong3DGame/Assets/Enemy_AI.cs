using UnityEngine;
using System.Collections;

public class Enemy_AI : MonoBehaviour {

    public Transform ball;
    public Ball_behavior ballVars;
    public float bounds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        float speedX = ballVars.speedX;
        float speedY = ballVars.speedY;
        float speedZ = ballVars.speedZ;

        float x = ballVars.x;
        float y = ballVars.y;
        float z = ballVars.z;

        while (z < -80)
        {
            float distToX;
            if (speedX > 0)
            { distToX = Mathf.Abs(bounds  - x); }
            else
            { distToX = Mathf.Abs(-bounds - x); }
            float distToY;
            if (speedY > 0)
            { distToY = Mathf.Abs(bounds  - y); }
            else
            { distToY = Mathf.Abs(-bounds - y); }

            if (distToY < distToX)
            { 
            
            }
            else
            {

            }
        }*/
	}
}
