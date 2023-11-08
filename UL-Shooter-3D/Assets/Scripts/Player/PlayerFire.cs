using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public float range = 100f;
    private float bulletDamage = 1f;
    public Camera fpsCamera;

    private bool shotgunSaturdayNight = false;
    
    [SerializeField]
    private float rifleBullets = 100f;
    [SerializeField]
    private float shotgunBullets = 50f;
    private float numberOfBullets;

    [SerializeField]
    private GameObject weaponUI;

    private void Awake()
    {
        numberOfBullets = rifleBullets;
    }

    private void Start()
    {
      weaponUI.GetComponent<PlayerBullets>().bulletUpdater(numberOfBullets);  
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
    }

    public void Fire()
    {
        if(shotgunSaturdayNight == false && rifleBullets > 0f)
        {
            numberOfBullets -= 1;
            rifleBullets -= 1;
            weaponUI.GetComponent<PlayerBullets>().bulletUpdater(numberOfBullets);

            RaycastHit hit;

            if (Physics.Raycast(
                    transform.position,
                    transform.forward,
                    out hit,
                    10f)
                )
                {
                //Choca con algo
                    Quaternion lookAt = Quaternion.LookRotation(hit.normal);
                    GameObject temp = Resources.Load<GameObject>("BulletCollision");
                    var obj = Instantiate(
                        temp,
                        hit.point,
                        lookAt
                    );

                    Destroy(obj, 3f);
                }

            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
            {
                var enemy = hit.transform.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage(bulletDamage);
                }
            }
        }
        else if(shotgunSaturdayNight == true && shotgunBullets > 0f)
        {
            numberOfBullets -= 1;
            shotgunBullets -= 1;
            weaponUI.GetComponent<PlayerBullets>().bulletUpdater(numberOfBullets);
            
            RaycastHit hit;

            if (Physics.Raycast(
                    transform.position,
                    transform.forward,
                    out hit,
                    10f)
                )
                {
                //Choca con algo
                    Quaternion lookAt = Quaternion.LookRotation(hit.normal);
                    GameObject temp = Resources.Load<GameObject>("BulletCollision");
                    var obj = Instantiate(
                        temp,
                        hit.point,
                        lookAt
                    );

                    Destroy(obj, 3f);
                }

            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
            {
                var enemy = hit.transform.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage(bulletDamage);
                }
            }
        }
        
    }

    public void shotgunActivator()
    {
        if (shotgunSaturdayNight == false)
        {
            shotgunSaturdayNight = true;
            bulletDamage = 3f;
            numberOfBullets = shotgunBullets;
            weaponUI.GetComponent<PlayerBullets>().bulletUpdater(numberOfBullets);
        }
        else if (shotgunSaturdayNight == true)
        {
            shotgunSaturdayNight = false;
            bulletDamage = 1f;
            numberOfBullets = rifleBullets;
            weaponUI.GetComponent<PlayerBullets>().bulletUpdater(numberOfBullets);
        }
        
    }
}
