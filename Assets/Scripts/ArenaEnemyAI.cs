using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArenaEnemyAI : MonoBehaviour
{
    public float MaxShootRadius = 15f;
    public float MaxLookRadius = 30f;
    public Animator Enemy;
    public GameObject projectile;
    private float shotInterval = 2f;
    public GameObject EnemyGunEnd;
    public float bulletspeed = 2;
    public bool IsAlive = true;

    private float shotTime;
    private Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FaceTarget();
        float distance = Vector3.Distance(target.position, this.transform.position);
        if (distance < MaxShootRadius && shotInterval < (Time.time - shotTime))
        {
            Enemy.SetBool("Shoot", true);
            Enemy.SetBool("Walk", false);
            StartCoroutine(Shoot());
        }
        if (distance < MaxLookRadius && distance > MaxShootRadius)
        {
            agent.SetDestination(target.position);
            Enemy.SetBool("Walk", true);
            Enemy.SetBool("Shoot", false);
        }
        if (distance > MaxLookRadius)
        {
            Enemy.SetBool("Walk", false);
            Enemy.SetBool("Shoot", false);
        }
    }

    IEnumerator Shoot()
    {
        shotTime = Time.time;
        yield return new WaitForSeconds(1f);
        Instantiate(projectile, EnemyGunEnd.transform.position + (target.position - transform.position).normalized, Quaternion.LookRotation(target.position - transform.position));
        this.GetComponent<AudioSource>().Play();
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

}
