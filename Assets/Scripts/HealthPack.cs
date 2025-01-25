using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public GameObject FX;

    Transform target;
    private int thisX;
    private int thisZ;
    private int targetZ;
    private int targetX;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    void Update()
    {
        ShootableBox health = target.gameObject.GetComponent<ShootableBox>();
        thisX = Mathf.RoundToInt(this.transform.position.x);
        thisZ = Mathf.RoundToInt(this.transform.position.z);
        targetX = Mathf.RoundToInt(target.transform.position.x);
        targetZ = Mathf.RoundToInt(target.transform.position.z);
        if (thisX == targetX && thisZ == targetZ)
        {
            Global.healCount += 1;
            Destroy(this.gameObject);
            Instantiate(FX, target.transform.position, target.transform.rotation);
            health.Damage(-3);
        }
    }
}
