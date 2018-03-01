using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WeaponSwitcher : MonoBehaviour {

    public int currentWeapon = 0;
    [Header("Weapons")]
    [Space(-20)]
    [Header("________________________________")]
    [Space(10)]

    public bool canShoot;

    Image currentGunImage;

    public bool charging;
    public float damage;

    AudioSource charge;
    AudioSource shoot;

    private void Update()
    {
        if(damage > 5)
        {

        }
        if (charging)
        {
            if (damage < 5)
            {
                Debug.Log(damage);
                damage += 0.07f;
            }
        }

        if (currentWeapon == 1 && !GameManager.instance.hasPistol)
        {
            Debug.Log("Does not have Pistol");
            ChangeWeapon();
        }
        if (currentWeapon == 2 && !GameManager.instance.hasShotgun)
        {
            Debug.Log("Does not have Shotgun");
            ChangeWeapon();
        }
        if (currentWeapon == 3 && !GameManager.instance.hasUzi)
        {
            Debug.Log("Does not have Uzi");
            ChangeWeapon();
        }
        if (currentWeapon == 4 && !GameManager.instance.hasRaygun)
        {
            Debug.Log("Does not have Raygun");
            ChangeWeapon();
        }
        if (currentWeapon == 5 && !GameManager.instance.hasBoomerang)
        {
            Debug.Log("Does not have Boomerang");
            ChangeWeapon();
        }
        if (currentWeapon == 6 && !GameManager.instance.hasCannon)
        {
            Debug.Log("Does not have Cannon");
            ChangeWeapon();
        }
    }

    void Start () {
        shoot = GameObject.Find("Shoot").GetComponent<AudioSource>();
        charge = GameObject.Find("Charge").GetComponent<AudioSource>();
        currentGunImage = GameObject.Find("WeaponHolderImage").GetComponent<Image>();
        SelectWeapon();
        canShoot = false;
	}
	
    public void ChangeWeapon()
    {
        if (currentWeapon >= transform.childCount - 1)
        {
            currentWeapon = 0;
            SelectWeapon();
        }
        else
        {
            currentWeapon++;
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
                currentGunImage.sprite = weapon.gameObject.GetComponent<Weapon>().gunSprite;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            shoot.Play();
            if (currentWeapon != 4)
            {
                foreach (Transform weapon in transform)
                {
                    if (weapon.gameObject.activeSelf)
                    {
                        weapon.gameObject.GetComponent<Weapon>().Shoot();
                    }
                }
            }
        }
    }

    public void RaygunUp()
    {
        if(canShoot) {
            if (currentWeapon == 4)
            {
                charge.Stop();
                shoot.Play();
                charging = false;
                foreach (Transform weapon in transform)
                {
                    if (weapon.gameObject.activeSelf)
                    {
                        weapon.gameObject.GetComponent<Weapon>().Raygun(damage);
                        damage = 0;
                    }
                }
            }
        }
    }

    public void RaygunDown()
    {
        if (canShoot)
        {
            if (currentWeapon == 4)
            {
                charge.Play();
                charging = true;
            }
        }
    }

    public void CallNumerator(float i)
    {
        StartCoroutine(ShootDelay(i));
    }

    IEnumerator ShootDelay(float i)
    {
        canShoot = false;
        yield return new WaitForSeconds(i);
        canShoot = true;
    }
}
