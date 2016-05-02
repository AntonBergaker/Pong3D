using UnityEngine;
using System.Collections;

public class PaddleInputParent : MonoBehaviour {

    public virtual Vector2 GetInput()
    {
        return new Vector2(0,0);
    }
}
