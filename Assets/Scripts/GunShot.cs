using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GunShot : MonoBehaviour
{
    public int gunDamage = 1;
    public float firerate = .5f;
    public float weaponrange = 10f;
    public float hitforce = 100;
    public Transform gunEnd;
    public int reload = 5;
    public Animator Gun;
    public TMPro.TextMeshPro AmmoLeft;
    public GameObject Katana;
    public Animator ForKatana;
    public int katanaDamage = 3;
    public GameObject BladeBeginning;
    public GameObject BladeEnd;
    public LayerMask Enemies;
    public GameObject ForReload;
    public int GunKatana;

    private bool AbilityAvailable = true;
    private Camera fpsCam;
    private WaitForSeconds shotduration = new WaitForSeconds(0.7f);
    private float sliceduration = 2f;
    private LineRenderer laserLine;
    private float nextFire;
    private float nextSlice = 1f;
    private bool wait;
    private bool KatEquiped;
    private float NextSlice;
    private int maxAmmo;
    private int PreviousGunKat;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
        maxAmmo = reload;
        GunKatana = 1;
        KatEquiped = false;
    }

    void Update()
    {
        StartCoroutine(GunKatanaSwap());
        if (GunKatana == 1)
        {
            AmmoLeft.SetText(reload.ToString());
            if (reload <= 0)
            {
                ForReload.GetComponent<AudioSource>().Play();
                StartCoroutine(Reload());
            }
            if (reload != maxAmmo && Input.GetKeyDown(KeyCode.R))
            {
                ForReload.GetComponent<AudioSource>().Play();
                StartCoroutine(Reload());
            }
            if (wait != true)
            {
                if (Input.GetButtonDown("Fire1") && Time.time > nextFire && ForPause.IsPaused == false)
                {
                    this.GetComponent<AudioSource>().Play();
                    reload -= 1;
                    nextFire = Time.time + firerate;

                    StartCoroutine(ShotEffect());

                    Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
                    RaycastHit hit;

                    laserLine.SetPosition(0, gunEnd.position);

                    if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponrange))
                    {
                        laserLine.SetPosition(1, hit.point);

                        ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                        if (health != null && hit.collider.gameObject.CompareTag("Enemy"))
                        {
                            health.Damage(gunDamage);
                        }

                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * hitforce);
                        }
                    }
                    else
                    {
                        laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponrange));
                    }
                }
            }
        }

            if ( GunKatana == 2 && Input.GetKeyDown(KeyCode.Mouse0) && Time.time > NextSlice && ForPause.IsPaused == false)
            {
                NextSlice = Time.time + 2 * nextSlice;
                StartCoroutine(KatSlice());
                Collider[] HitEnemies = Physics.OverlapSphere(BladeBeginning.transform.position, 1f, Enemies);
                foreach (Collider enemy in HitEnemies)
                {
                    ShootableBox health = enemy.GetComponent<ShootableBox>();

                    if (health != null)
                    {
                        health.Damage(katanaDamage);
                    }
                }
            Collider[] HitEnemies2 = Physics.OverlapSphere(BladeEnd.transform.position, 0.5f, Enemies);
            foreach (Collider enemy in HitEnemies2)
            {
                ShootableBox health = enemy.GetComponent<ShootableBox>();

                if (health != null)
                {
                    health.Damage(katanaDamage);
                }
            }
            if (Time.time < NextSlice)
                {
                    StartCoroutine(ShortSlice());
                }
            }
        if (AbilityAvailable == true)
        {

            if ( GunKatana == 3 && Input.GetKeyDown(KeyCode.Mouse0) && Time.time > NextSlice && ForPause.IsPaused == false)
            {
                StartCoroutine(NextAbilityStart());
                NextSlice = Time.time + 2 * nextSlice;
                Katana.GetComponent<AudioSource>().Play();
                StartCoroutine(KatCombinationSlice());
                Collider[] HitEnemies = Physics.OverlapSphere(BladeBeginning.transform.position, 1f, Enemies);
                foreach (Collider enemy in HitEnemies)
                {
                    ShootableBox health = enemy.GetComponent<ShootableBox>();

                    if (health != null)
                    {
                        health.Damage(katanaDamage);
                    }
                }
                Collider[] HitEnemies2 = Physics.OverlapSphere(BladeEnd.transform.position, 1f, Enemies);
                foreach (Collider enemy in HitEnemies2)
                {
                    ShootableBox health = enemy.GetComponent<ShootableBox>();

                    if (health != null)
                    {
                        health.Damage(katanaDamage);
                    }
                }
                AmmoLeft.SetText(reload.ToString());
                if (reload <= 0)
                {
                    ForReload.GetComponent<AudioSource>().Play();
                    StartCoroutine(Reload());
                }
                if (reload != maxAmmo && Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(Reload());
                }
                if (wait != true)
                {
                    if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
                    {
                        this.GetComponent<AudioSource>().Play();
                        reload -= 1;
                        nextFire = Time.time + firerate;

                        StartCoroutine(ShotEffect());

                        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
                        RaycastHit hit;

                        laserLine.SetPosition(0, gunEnd.position);

                        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponrange))
                        {
                            laserLine.SetPosition(1, hit.point);

                            ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                            if (health != null && hit.collider.gameObject.CompareTag("Enemy"))
                            {
                                health.Damage(gunDamage);
                            }

                            if (hit.rigidbody != null)
                            {
                                hit.rigidbody.AddForce(-hit.normal * hitforce);
                            }
                        }
                        else
                        {
                            laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponrange));
                        }
                    }
                }
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotduration;
        laserLine.enabled = false;
    }

    private IEnumerator Reload()
    {
        wait = true;
        Gun.SetBool("IsReloading", true);
        yield return new WaitForSeconds(0.5f * Time.deltaTime);
        reload = 5;
        yield return new WaitForSeconds(0.5f * Time.deltaTime);
        Gun.SetBool("IsReloading", false);
        yield return new WaitForSeconds(1);
        wait = false;
    }

    private IEnumerator GunKatanaSwap()
    {
        if (GunKatana != 3)
        {
            if (KatEquiped == false)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    KatEquiped = true;
                    Gun.SetBool("IsEquiped", false);
                    GunKatana = 2;
                    yield return new WaitForSeconds(0.5f);
                    Katana.GetComponent<MeshCollider>().enabled = true;
                    ForKatana.SetBool("IsEquiped", true);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    KatEquiped = false;
                    ForKatana.SetBool("IsEquiped", false);
                    GunKatana = 1;
                    yield return new WaitForSeconds(0.5f);
                    Katana.GetComponent<MeshCollider>().enabled = false;
                    Gun.SetBool("IsEquiped", true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && AbilityAvailable == true)
        {
            PreviousGunKat = GunKatana;
            GunKatana = 3;
            ForKatana.SetBool("Combination", true);
            Gun.SetBool("IsEquiped", true);
            yield return new WaitForSeconds(10f);
            GunKatana = PreviousGunKat;
            ForKatana.SetBool("Combination", false);
            if (GunKatana == 1)
            {
                KatEquiped = false;
                ForKatana.SetBool("IsEquiped", false);
                yield return new WaitForSeconds(0.5f);
                Katana.GetComponent<MeshCollider>().enabled = false;
                Gun.SetBool("IsEquiped", true);
            }
            if (GunKatana == 2)
            {
                KatEquiped = true;
                Gun.SetBool("IsEquiped",false);
                yield return new WaitForSeconds(0.5f);
                Katana.GetComponent<MeshCollider>().enabled = true;
                ForKatana.SetBool("IsEquiped", true);
            }
            StartCoroutine(NextAbilityEnd());
        }
        
    }

    private IEnumerator KatSlice()
    {
        ForKatana.SetBool("LongSlice", true);
        Katana.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.25f);
        Katana.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.25f);
        Katana.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        Collider[] HitEnemies = Physics.OverlapSphere(BladeBeginning.transform.position, 1f, Enemies);
                foreach (Collider enemy in HitEnemies)
                {
                    ShootableBox health = enemy.GetComponent<ShootableBox>();

                    if (health != null)
                    {
                        health.Damage(katanaDamage);
                    }
                }
        ForKatana.SetBool("LongSlice", false);
    }

    private IEnumerator KatCombinationSlice()
    {
        ForKatana.SetBool("CombinationAttack", true);
        yield return new WaitForSeconds(0.25f);
        Collider[] HitEnemies = Physics.OverlapSphere(BladeBeginning.transform.position, 0.1f, Enemies);
        foreach (Collider enemy in HitEnemies)
        {
            ShootableBox health = enemy.GetComponent<ShootableBox>();

            if (health != null)
            {
                health.Damage(katanaDamage);
            }
        }
        ForKatana.SetBool("CombinationAttack", false);
    }

    private IEnumerator ShortSlice ()
    {
        ForKatana.SetBool("ShortSlice", true);
        yield return new WaitForSeconds(sliceduration/4);
        ForKatana.SetBool("ShortSlice", false);
    }

    private IEnumerator NextAbilityStart()
    {
        yield return new WaitForSeconds(10);
        AbilityAvailable = false;
    }

    private IEnumerator NextAbilityEnd()
    {
        yield return new WaitForSeconds(30);
        AbilityAvailable = true;
    }
}