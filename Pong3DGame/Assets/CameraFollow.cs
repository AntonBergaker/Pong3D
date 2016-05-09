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

        float targetX, targetY;

        targetX = (ball.position.x + paddle.position.x + 0) / 3; //get the center point of ball, paddle and the middle of the playing field
        targetY = (ball.position.y + paddle.position.y + 0) / 3;

        x = Mathf.Lerp(targetX, x, 1 - Time.deltaTime); //not framerate independant but close enough
        y = Mathf.Lerp(targetY, y, 1 - Time.deltaTime);

        body.position = new Vector3(x, y, z); //move the camera to the x, y and z
        
        body.LookAt(new Vector3(targetX, targetY, ball.position.z));
	}
}
