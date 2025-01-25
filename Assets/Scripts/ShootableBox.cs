using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShootableBox : MonoBehaviour
{
    public int currenthealth = 3;
    public GameObject ShaterObject;
    public Animator enemy;
    public Transform ForFX;
    public GameObject DeathEfect;
    public GameObject Col;
    public GameObject Camera;
    public GameObject OldCamera;
    public GameObject Gun;
    public GameObject Blade;
    public GameObject ForDrop;
    public GameObject ForDropG;
    public int Score;
    private GameObject player;
    private int MaxHealth;
    public GameObject EndCanvas;
    public TMPro.TextMeshProUGUI MaxScore;
    private GameObject PlayerGun;
    public GameObject Alert;
    public TMPro.TextMeshProUGUI ForScore;
    public Animator BossAnim;
    private int levelIndex;

    void Start()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        player = PlayerManager.instance.player;
        MaxHealth = currenthealth;
        Score = 0;
        PlayerGun = GameObject.FindGameObjectWithTag("PlayerGun");
    }
    void Update()
    {
        if (currenthealth >= MaxHealth)
        {
            currenthealth = MaxHealth;
        }
        if (ForScore != null)
        {
            ForScore.SetText("Score: " + player.GetComponent<ShootableBox>().Score);
        }
        if (this.CompareTag("Player") && currenthealth <= 0)
        {
            currenthealth = 0;
            Instantiate(Camera, OldCamera.transform.position, OldCamera.transform.rotation);
            Destroy(OldCamera.gameObject);
            Time.timeScale = 0.2f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (ForDropG != null)
            {
                Instantiate(Gun, ForDropG.transform.position, ForDropG.transform.rotation);
            }
            Destroy(Gun.GetComponent<GunShot>());
            Destroy(PlayerGun.gameObject);
            if (ForDrop != null)
            {
                Instantiate(Blade, ForDrop.transform.position, ForDrop.transform.rotation);
            }
            if (player.GetComponent<ShootableBox>().Score > Global.MaxScore && MaxScore != null)
            {
                Global.MaxScore = player.GetComponent<ShootableBox>().Score;
                MaxScore.SetText("New High Score!");
            }
            else
            {
                MaxScore.SetText("High Score: " + Global.MaxScore);
            }
            if (Global.MaxScore >= 1 && Global.unlockedFor1 == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor1 = true;
            }
            if (Global.MaxScore >= 25 && Global.unlockedFor15 == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor15 = true;
            }
            if (Global.MaxScore >= 50 && Global.unlockedFor25 == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor25 = true;
            }
            if (Global.MaxScore >= 100 && Global.unlockedFor50 == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor50 = true;
            }
            if (Global.PistolKills >= 100 && Global.unlockedFor50Gun == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor50Gun = true;
            }
            if (Global.KatKills >= 100 && Global.unlockedFor50Katana == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor50Katana = true;
            }
            if (Global.healCount >= 20 && Global.unlockedFor20Heal == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor20Heal = true;
            }
            Destroy(this.gameObject);
        }
        if (this.gameObject.GetComponent<BossTest>() == true && currenthealth <= 0)
        {
            Destroy(this.gameObject.GetComponent<BossTest>());
            Destroy(this.gameObject.GetComponent<MeshCollider>());
            BossAnim.SetTrigger("Death");
            StartCoroutine(BossDeath());
        }
    }

        public void Damage (int damageAmount)
    {
        currenthealth -= damageAmount;
        if (this.CompareTag("Enemy") && currenthealth <= 0)
        {
            if (PlayerMovement.isGrounded != true)
            {
                Global.AirKills += 1;
            }
            if (enemy != null)
            {
                enemy.SetBool("Walk", false);
                enemy.SetBool("Shoot", false);
                enemy.SetTrigger("die");
                player.GetComponent<ShootableBox>().Score = player.GetComponent<ShootableBox>().Score + 1;
            }
            if (this.gameObject.GetComponent<EnemyAI>() == true)
            {
                Destroy(Col.gameObject.GetComponent<BoxCollider>());
                Destroy(this.gameObject.GetComponent<EnemyAI>());
            }
            if (this.gameObject.GetComponent<ArenaEnemyAI>() == true) 
            {
                if (PlayerGun.GetComponent<GunShot>().GunKatana == 1)
                {
                    Global.PistolKills += 1;
                }
                if (PlayerGun.GetComponent<GunShot>().GunKatana == 2)
                {
                    Global.KatKills += 1;
                }
                if (PlayerGun.GetComponent<GunShot>().GunKatana == 3)
                {
                    Global.PistolKills += 1;
                    Global.KatKills += 1;
                }
                Destroy(Col.gameObject.GetComponent<BoxCollider>());
                Destroy(this.gameObject.GetComponent<ArenaEnemyAI>());
            }
            if(this.gameObject.GetComponent<BombAI>() == true)
            {
                if (PlayerGun.GetComponent<GunShot>().GunKatana == 1)
                {
                    Global.PistolKills += 1;
                }
                if (PlayerGun.GetComponent<GunShot>().GunKatana == 2)
                {
                    Global.KatKills += 1;
                }
                if (PlayerGun.GetComponent<GunShot>().GunKatana == 3)
                {
                    Global.PistolKills += 1;
                    Global.KatKills += 1;
                }
                Instantiate(DeathEfect, ForFX.position, Quaternion.identity);
                player.GetComponent<ShootableBox>().Score = player.GetComponent<ShootableBox>().Score + 1;
                Destroy(this.gameObject);
            }
            if (this.gameObject.GetComponent<BossTest>() == true && currenthealth <= 0)
            {
                Destroy(this.gameObject.GetComponent<BossTest>());
                Destroy(Col.gameObject.GetComponent<MeshCollider>());
                BossAnim.SetTrigger("Death");
                StartCoroutine(BossDeath());
            }
        }
        if(currenthealth <= 0 && this.CompareTag("Enemy") != true && this.CompareTag("Player") != true && this.CompareTag("Boss") != true)
        {
            if (ShaterObject != null)
            {
                Instantiate(ShaterObject, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
        if (this.CompareTag("Player") && currenthealth <= 0)
        { 
            currenthealth = 0;
            Instantiate(Camera, OldCamera.transform.position, OldCamera.transform.rotation);
            Destroy(OldCamera.gameObject);
            Time.timeScale = 0.2f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (ForDropG != null)
            {
                Instantiate(Gun, ForDropG.transform.position, ForDropG.transform.rotation);
            }
            Destroy(Gun.GetComponent<GunShot>());
            Destroy(PlayerGun.gameObject);
            if (ForDrop != null)
            {
                Instantiate(Blade, ForDrop.transform.position, ForDrop.transform.rotation);
            }
            if (levelIndex == 3)
            {
                if (player.GetComponent<ShootableBox>().Score > Global.MaxScore && MaxScore != null)
                {
                    Global.MaxScore = player.GetComponent<ShootableBox>().Score;
                    MaxScore.SetText("New High Score!");

                }
                else
                {
                    MaxScore.SetText("High Score: " + Global.MaxScore);
                }
            }
            if (Global.MaxScore >= 1 && Global.unlockedFor1 == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor1 = true;
            }
            if (Global.MaxScore >= 25 && Global.unlockedFor15 == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor15 = true;
            }
            if (Global.MaxScore >= 50 && Global.unlockedFor25 == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor25 = true;
            }
            if (Global.MaxScore >= 100 && Global.unlockedFor50 == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor50 = true;
            }
            if (Global.PistolKills >= 100 && Global.unlockedFor50Gun == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor50Gun = true;
            }
            if (Global.KatKills >= 100 && Global.unlockedFor50Katana == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor50Katana = true;
            }
            if (Global.healCount >= 20 && Global.unlockedFor20Heal == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedFor20Heal = true;
            }
            if (Global.AirKills >= 1 && Global.unlockedForAir == false)
            {
                Instantiate(Alert, new Vector3(0, 0, 0), Quaternion.identity);
                Global.unlockedForAir = true;
            }
            Destroy(this.gameObject);
        }
    }

    IEnumerator BossDeath()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(2f);
        Time.timeScale = 1f;
        Global.passedLevel5 = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}