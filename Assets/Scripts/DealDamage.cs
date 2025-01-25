using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        ShootableBox health = other.gameObject.GetComponent<ShootableBox>();

        if (health != null)
        {
            health.Damage(1);
        }
        Destroy(this.gameObject);
    }
}
