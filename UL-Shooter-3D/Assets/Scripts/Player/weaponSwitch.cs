using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeapon = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Oculta el arma actual
            weapons[currentWeapon].SetActive(false);

            // Cambia al siguiente arma
            currentWeapon = (currentWeapon + 1) % weapons.Length;

            // Muestra el nuevo arma
            weapons[currentWeapon].SetActive(true);
        }
    }
}