using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Body;
    public GameObject Bomb;
    public GameObject HealthPack;

    private int multiply;
    private bool needHealth = false;
    private float nextSpawn;
    GameObject target;

    void Start()
    {
        
        target = PlayerManager.instance.player;
        Invoke("SpawnBody", 7);
        Invoke("SpawnAgent", 7);
    }
    void Update()
    {
        SpawnHealthPack();
    }

    void SpawnAgent()
    {
        Vector3 position = new Vector3(Random.Range(63.2f, -91.25f), Random.Range(-0.5f, 10f), Random.Range(49.0f, -64.6f));
        Instantiate(Bomb, position, Quaternion.identity);
        Invoke("SpawnAgent", 8);
    }
    void SpawnBody()
    {
        Vector3 position = new Vector3(Random.Range(63.2f, -91.25f), Random.Range(-0.5f, 10f), Random.Range(49.0f, -64.6f));
        Instantiate(Body, position, Quaternion.identity);
        Invoke("SpawnBody", 8);
    }
    void SpawnHealthPack()
    {
        if (target.GetComponent<ShootableBox>().currenthealth < 7)
        {
            if (needHealth == false)
            {
                needHealth = true;
                nextSpawn = Time.time + 30 - (-(target.GetComponent<ShootableBox>().currenthealth - 7)) * 3;
            }
            
            if (needHealth == true && Time.time > nextSpawn)   
            {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                Vector3 position = new Vector3(Random.Range(63.2f, -91.25f), Random.Range(1, 11f), Random.Range(49.0f, -64.6f));
                Instantiate(HealthPack, position, lookRotation);
            nextSpawn = Time.time + 34 - (-(target.GetComponent<ShootableBox>().currenthealth - 7)) * 3;
            }
        }
        else 
        {
            needHealth = false;
        }
    }
}
