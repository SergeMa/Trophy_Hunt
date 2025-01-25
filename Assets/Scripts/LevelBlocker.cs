using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlocker : MonoBehaviour
{
    public GameObject BlockCube;
    public GameObject BlockCube2;
    public GameObject BlockCube3;

    public void OnTriggerEnter()
    {
        Destroy(BlockCube.gameObject);
        Destroy(BlockCube2.gameObject);
        Destroy(BlockCube3.gameObject);
        Destroy(this.gameObject);
    }
}
