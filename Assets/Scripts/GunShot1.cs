using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GunShot1 : MonoBehaviour
{
    public int gunDamage = 1;
    public float firerate = .5f;
    public float weaponrange = 10f;
    public float hitforce = 100;
    public Transform gunEnd;
    public int reload = 5;
    public Animator Gun;
    public TMPro.TextMeshPro AmmoLeft;
    public AudioClip ReloadSound;
    public AudioClip Shoot;

    private Camera fpsCam;
    private WaitForSeconds shotduration = new WaitForSeconds(0.7f);
    private LineRenderer laserLine;
    private float nextFire;
    private bool wait;
    private bool KatEquiped;
    private int maxAmmo;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
        maxAmmo = reload;
    }
    void Update()
    {
        AmmoLeft.SetText(reload.ToString());
        if (reload <= 0)
        {
            StartCoroutine(Reload());
            this.GetComponent<AudioSource>().clip = ReloadSound;
            this.GetComponent<AudioSource>().Play();
        }
        if (reload != maxAmmo && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            this.GetComponent<AudioSource>().clip = ReloadSound;
            this.GetComponent<AudioSource>().Play();
        }
        if (wait != true)
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextFire && ForPause.IsPaused == false)
            {
                reload -= 1;
                nextFire = Time.time + firerate;
                this.GetComponent<AudioSource>().clip = Shoot;
                this.GetComponent<AudioSource>().Play();

                StartCoroutine(ShotEffect());

                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
                RaycastHit hit;

                laserLine.SetPosition(0, gunEnd.position);

                if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponrange))
                {
                    laserLine.SetPosition(1, hit.point);

                    ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                    if (health != null && hit.collider.gameObject.CompareTag("Enemy") || health != null && hit.collider.gameObject.CompareTag("Boss") || health != null && hit.collider.gameObject.CompareTag("Box"))
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

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotduration;
        laserLine.enabled = false;
    }
}
