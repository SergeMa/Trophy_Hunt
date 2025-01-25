using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCounter : MonoBehaviour
{
    public GameObject FpsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if(MouseSence.fpsCount == true)
        {
            Instantiate(FpsCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
