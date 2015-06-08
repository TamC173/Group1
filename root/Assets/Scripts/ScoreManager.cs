using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
   
    public static ScoreManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ScoreManager>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this.gameObject.GetComponent<ScoreManager>();
            
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }
    
    //private score.
    //this is the score that is local to the scoremanager
    private float _score = 0;

    //this is the score that we expose to everyone.
    public float Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    void Update()
    {


        if(fTimer.timerDone)
        {
            //iwin
            if (_score >= 15)
            {
                //tell gameman u won or something
                Application.LoadLevel("FallingEnd");
            }
            //u suck :(
            else
                Application.LoadLevel("Map_Layout");
        }
    }

    public Timer fTimer;
    private static ScoreManager _instance;
    
}
