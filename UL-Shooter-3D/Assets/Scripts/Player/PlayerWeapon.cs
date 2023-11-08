using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject shotgunIcon;
    [SerializeField]
    private GameObject rifleIcon;
    private bool shotgunSaturdayNight = false;

    public void iconActivator()
    {
        if (shotgunSaturdayNight == false)
        {
            shotgunSaturdayNight = true;
            this.rifleIcon.SetActive(false);
            this.shotgunIcon.SetActive(true);
            

        }
        else if (shotgunSaturdayNight == true)
        {
            shotgunSaturdayNight = false;
            this.rifleIcon.SetActive(true);
            this.shotgunIcon.SetActive(false);
        }
        
    }
}
