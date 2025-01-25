using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClean : MonoBehaviour
{
    public float delay = 5f;
    IEnumerator Start ()
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
