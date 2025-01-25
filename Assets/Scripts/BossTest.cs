using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossTest : MonoBehaviour
{
    public float MaxShootRadius = 5f;
    public float MaxLookRadius = 20f;
    public Animator BossAnim;
    public GameObject Katana;
    public GameObject BladeBeginning;
    public LayerMask Enemies;
    public GameObject BossHealthBar;

    private float shotTime;
    private float distance;
    private Transform target;
    NavMeshAgent agent;
    private int attack;
    private bool attackReady = true;
    private float PreviousAttack;
    private bool HasAttacked = false;
    private bool healthBarActive = false;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FaceTarget();
        distance = Vector3.Distance(target.position, this.transform.position);
        if(distance <= 60 && healthBarActive == false)
        {
            Instantiate(BossHealthBar, new Vector3(0, 0, 0), Quaternion.identity);
            healthBarActive = true;

        }
        if (distance <= MaxLookRadius)
        {
            if (attackReady == true && distance <= MaxShootRadius)
            {
                attack = Mathf.RoundToInt(Random.Range(1, 2));
                PreviousAttack = Time.time + 4;
                this.GetComponent<AudioSource>().Play();
                if (attack == 1)
                {
                    BossAnim.SetTrigger("RegularAttack");
                    Collider[] HitEnemies = Physics.OverlapSphere(BladeBeginning.transform.position, 3f, Enemies);
                    StartCoroutine(Attack());
                    attackReady = false;
                    HasAttacked = true;
                }
                if (attack == 2)
                {
                    BossAnim.SetTrigger("SpinAttack");
                    StartCoroutine(Attack());
                    attackReady = false;
                    HasAttacked = true;
                }
                BossAnim.SetTrigger("Free");
            }
            if (distance > MaxShootRadius)
            {
                BossAnim.SetTrigger("Walk");
                agent.SetDestination(target.position);
                attackReady = true;
            }
            if (Time.time > PreviousAttack && HasAttacked == true)
            {
                attackReady = true;
                HasAttacked = false;
            }
        }
        if(this.gameObject.GetComponent<ShootableBox>().currenthealth <= 0)
        {
            Destroy(BossHealthBar.gameObject);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(-direction.x, 0, -direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2);
        Collider[] HitEnemies = Physics.OverlapSphere(BladeBeginning.transform.position, 3f, Enemies);
        foreach (Collider enemy in HitEnemies)
        {
            ShootableBox health = enemy.GetComponent<ShootableBox>();

            if (health != null)
            {
                health.Damage(3);
            }
        }
    }
}
