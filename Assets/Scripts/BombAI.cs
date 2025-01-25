using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BombAI : MonoBehaviour
{
    public float MaxLookRadius = 30f;
    public Transform ForFX;
    Transform target;
    NavMeshAgent agent;

    public GameObject Efect;

    private int thisX;
    private int thisZ;
    private int targetZ;
    private int targetX;
    private int thisY;
    private int targetY;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, this.transform.position);
        if (distance < MaxLookRadius)
        {
            agent.SetDestination(target.position);
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
        }
        ShootableBox health = target.gameObject.GetComponent<ShootableBox>();
        thisX = Mathf.RoundToInt(this.transform.position.x);
        thisZ = Mathf.RoundToInt(this.transform.position.z);
        targetX = Mathf.RoundToInt(target.transform.position.x);
        targetZ = Mathf.RoundToInt(target.transform.position.z);
        if (thisX == targetX && thisZ == targetZ)
        {
            Instantiate(Efect, ForFX.position, ForFX.rotation);
            Destroy(this.gameObject);
            health.Damage(3);
        }
    }
}
