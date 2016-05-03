using UnityEngine;
using System.Collections;

public class FollowBall : MonoBehaviour {

    public Transform ball;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, ball.position.z);
	}
}
