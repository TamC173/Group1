using UnityEngine;
using System.Collections;

public class MapLayout : MonoBehaviour {
    public void Transition(string lvl)
    {
        Application.LoadLevel(lvl);
    }



    /// <summary>
    /// gimme the wings?
    /// if wings is -1 default
    /// else make some states and button behavior
    /// </summary>
    /// <returns></returns>
    public int CheckGameState()
    {
        int currentState = -1;
        switch (currentState)
        {
            case 0:
                //lock all the buttons but falling
                break;
            case 1:
                //through 4
                break;

        }
        return -1;
    }

}
