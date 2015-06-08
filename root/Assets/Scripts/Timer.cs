using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public float myTimer = 30f;
	public bool timerDone = false;

	// Use this for initialization
	void Start () {
	
	}

    public void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 30;
        myStyle.normal.textColor = Color.yellow;
        //Display the timer
        string text = "Timer: " + myTimer;
        GUI.Label(new Rect(10, 10, 150, 100), text, myStyle);
    }
	
	// Update is called once per frame
	void Update () 
    {
        //If Timer is greater than 0, timer will countdown
        if (myTimer > 0)
        {
            myTimer -= Time.deltaTime;
			timerDone = false;
        }
		else 
		{ 
			timerDone = true; 
		}
	
	}

   
}
