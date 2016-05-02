using UnityEngine;
using System.Collections;

public class PaddlePlayer : PaddleInputParent {
    public override Vector2 GetInput()
    {
        float x = -Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        return new Vector2(x, y);
        Debug.Log("Test");
    }
}
