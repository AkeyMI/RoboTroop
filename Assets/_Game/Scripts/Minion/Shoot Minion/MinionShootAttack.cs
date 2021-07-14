using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinionShootAttack : MonoBehaviour
{
    //[SerializeField] GameObject bulletPrefab = default;
    [SerializeField] GameObject spawnBullet = default;
    //[SerializeField] float timeForAttack = 0.5f;
    //[SerializeField] int ammo = 5;
    //[SerializeField] float timeToReload = 1f;
    [SerializeField] ItemDistance item = default;

    private int currentAmmo;
    private bool isReloading = false;

    private float timeOfLastAttack;

    private MinionUiController minionUi;

    private void Start()
    {
        currentAmmo = item.ammo;
    }

    private void Update()
    {
        if (!CanShoot()) return;

        ShootOrReload();
    }

    private void ShootOrReload()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isReloading)
            {
                return;
            }

            if (currentAmmo > 0)
            {
                Shoot();
            }
            else
            {
                StartCoroutine(Reload());
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < item.ammo)
        {
            StartCoroutine(Reload());
        }
    }

    private bool CanShoot()
    {
        if (minionUi == null)
            minionUi = FindObjectOfType<MinionUiController>();

        if (minionUi != null && minionUi.gameObject.activeInHierarchy) 
            return false;

        return true;
    }

    IEnumerator Reload()
    {
        Debug.Log("Esta recargando");
        isReloading = true;

        yield return new WaitForSeconds(item.timeToReload);

        currentAmmo = item.ammo;

        isReloading = false;
    }

    private void Shoot()
    {
        if (Time.time > timeOfLastAttack)
        {
            GameObject bullet = Instantiate(item.bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
            bullet.GetComponent<Bullet>().Init(item.damage);
            timeOfLastAttack = Time.time + item.timeForAttack;
            currentAmmo--;
        }
    }

    public void ChangeItem(Item item)
    {
        this.item = (ItemDistance)item;
    }
}
