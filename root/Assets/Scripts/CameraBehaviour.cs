using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
    public bool cam = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ZoomCamera(cam);
        }
    }
    public void ZoomCamera(bool state)
    {
        Camera.main.GetComponent<Animator>().SetBool("in",state);
    }

}
