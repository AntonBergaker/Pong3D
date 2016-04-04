using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Transform body;
    public float speed;
    private float x;
    private float y;
    private float z;

	// Use this for initialization
	void Start () {
        x = body.transform.position.x;
        y = body.transform.position.y;
        z = body.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        x += moveX * Time.deltaTime * speed;
        y += moveY * Time.deltaTime * speed;

        body.transform.position = new Vector3(x, y, z);
	}
}
