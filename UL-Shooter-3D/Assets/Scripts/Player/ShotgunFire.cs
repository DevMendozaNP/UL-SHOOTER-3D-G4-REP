using UnityEngine;

public class ShotgunShooting : MonoBehaviour
{
    /*public float damage = 10f;
    public float range = 100f;
    public Camera fpsCamera;
    public Transform shotgunMuzzle;
    public GameObject shotgunParticlesPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            FireShotgun();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    void FireShotgun()
    {
        RaycastHit hit;

        if (Physics.Raycast(shotgunMuzzle.position, shotgunMuzzle.forward, out hit, 10f))
        {
            Debug.Log(hit.collider.transform.name);
            Quaternion lookAt = Quaternion.LookRotation(hit.normal);
            GameObject temp = Resources.Load<GameObject>("ShotgunParticles");
            var obj = Instantiate(temp, hit.point, lookAt);

            Destroy(obj, 2f);
        }
    }*/
}
