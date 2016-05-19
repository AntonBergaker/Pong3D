using UnityEngine;
using System.Collections;


[System.Serializable]
public class Difficulty
{
    public string name;
    public PaddleInputParent script;
    [HideInInspector]
    public float xTime = 0;
}
public class Menu : MonoBehaviour {

    public Difficulty[] difficulities;
    public GUIStyle font;
    public Color highlightColor;
    public Movement paddleMovement;
    public bool active = true;
    public Texture background;
    public Texture robert;

    private GameController controller;

    int selected = 0;

	// Use this for initialization
	void Start () {
        controller = GetComponent<GameController>();
        controller.freezeBall = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            { selected--; }
            if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
            { selected++; }

            selected = (selected + difficulities.Length) % difficulities.Length;

            if (Input.GetKeyDown("return") || Input.GetKeyDown("space"))
            {
                paddleMovement.inputScript = difficulities[selected].script;
                active = false;
                controller.freezeBall = false;
            }
        }
	}

    void OnGUI()
    {
        if (active)
        {
            int screenWidth = Screen.width;
            int screenHeight = Screen.height;

            GUI.DrawTexture(new Rect(0,0, screenWidth, screenHeight), background);
            GUI.DrawTexture(new Rect(screenWidth*0.6F - screenHeight*0.1F, screenHeight*0.3F - screenWidth*0.1F, screenHeight * 0.5F, screenHeight * 0.5F), robert);

            font.fontSize = (int)(screenHeight * 0.1F);
            float heightOffset = screenHeight * 0.2F;
            float heightDifference = screenHeight * 0.1F;
            float widthOffset = screenWidth * 0.05F;
            for (int i = 0; i < difficulities.Length; i++)
            {
                float xOffset = quadOutIn(0, screenWidth * 0.05F, difficulities[i].xTime, 1);
                font.normal.textColor = Color.Lerp(Color.white, highlightColor, difficulities[i].xTime);

                GUI.Label(new Rect(widthOffset + xOffset, heightOffset + heightDifference * i, 1F, 1F), difficulities[i].name, font);
                if (i == selected)
                { difficulities[i].xTime = Mathf.Clamp(difficulities[i].xTime + Time.deltaTime, 0, 1); }
                else
                { difficulities[i].xTime = Mathf.Clamp(difficulities[i].xTime - Time.deltaTime, 0, 1); }
            }
        }
    }


    float quadOutIn(float start, float end, float time, float duration)
    {
        float c = end - start;

        time /= duration / 2;
        if (time < 1)
        { return (c / 2 * time * time + start); }
        time--;
        return (-c / 2 * (time * (time - 2) - 1) + start);
    }
}