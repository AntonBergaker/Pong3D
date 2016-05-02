using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform body;
    public Transform ball;
    public Transform paddle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = body.position.x;
        float y = body.position.y;
        float z = body.position.z;

        float targetX;
        float targetY;
        targetX = Mathf.Lerp(ball.position.x  , 0, 0.5F);
        targetX = Mathf.Lerp(paddle.position.x, targetX, 0.33F);

        targetY = Mathf.Lerp(ball.position.y, 0, 0.5F);
        targetY = Mathf.Lerp(paddle.position.y, targetY, 0.33F);

        x = Mathf.Lerp(targetX, x, 1 - Time.deltaTime); //not framerate independant but close enough
        y = Mathf.Lerp(targetY, y, 1 - Time.deltaTime);

        body.position = new Vector3(x, y, z);
        
        body.LookAt(new Vector3(targetX, targetY, ball.position.z));
	}
}
