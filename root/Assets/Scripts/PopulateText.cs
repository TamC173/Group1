using UnityEngine;
using System.Collections;

public class PopulateText : MonoBehaviour {

    public void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " +  ScoreManager.instance.Score.ToString();
    }

    
} 