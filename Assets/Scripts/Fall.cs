using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public GameObject cube;


    public void OnTriggerEnter()
    {
        cube.AddComponent<Rigidbody>();
    }
}
