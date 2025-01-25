using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilCube : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ShootableBox>().currenthealth -= 10;
        }
    }
}
