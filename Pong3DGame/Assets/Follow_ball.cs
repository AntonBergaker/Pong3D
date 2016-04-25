using UnityEngine;
using System.Collections;

public class Follow_ball : MonoBehaviour {

    public Transform ball;
	
	// Update is called once per frame
	void Update () {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, ball.position.z);
        transform.position = position;
	}
}
