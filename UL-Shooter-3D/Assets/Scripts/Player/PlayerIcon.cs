using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerIcon : MonoBehaviour
{
    [SerializeField]
    private Image healthIcon;

    #region Iconos de vida
    [SerializeField]
    private GameObject fullShieldIcon;
    [SerializeField]
    private GameObject noShieldIcon;
    [SerializeField]
    private GameObject damageIcon;
    [SerializeField]
    private GameObject nearDeathIcon;
    [SerializeField]
    private GameObject deathIcon;
    #endregion

    #region Unidades de vida manejadas
    [SerializeField]
    private float healthCountStart = 100f;
    [SerializeField]
    private float shieldCountStart = 100f;
    private float healthCounter;
    private float shieldCounter;
    #endregion

    [SerializeField]
    private GameObject gameOver;

    private void Start()
    {
        //Registrando los niveles de vida asignados en el editor
        healthCounter = healthCountStart;
        shieldCounter = shieldCountStart;
    }

    private void Update()
    {
        shieldEnder();
        damageCounter();
        nearDeathExperience();
        deathFace();
    }

    public void damageChange(float damageGiver)
    {
        if (shieldCounter > 0f)
        {
            shieldCounter -= damageGiver;
        }
        else if (shieldCounter == 0f)
        {
            healthCounter -= damageGiver;
        }
    }

    private void shieldEnder()
    {
        if (shieldCounter <= 0f && healthCounter > 50f)
        {
            Debug.Log("Se envió info");
            this.fullShieldIcon.SetActive(false);
            this.noShieldIcon.SetActive(true);
        }
    }
    
    private void damageCounter()
    {
        if (healthCounter <= 50f && healthCounter > 25f)
        {
            this.noShieldIcon.SetActive(false);
            this.damageIcon.SetActive(true);
        }
    }

    private void nearDeathExperience()
    {
        if (healthCounter <= 25f && healthCounter > 0f)
        {
            this.damageIcon.SetActive(false);
            this.nearDeathIcon.SetActive(true);
        }
    }

    private void deathFace()
    {
        if (healthCounter <= 0f)
        {
            this.nearDeathIcon.SetActive(false);
            this.deathIcon.SetActive(true);
            this.gameOver.SetActive(true);
        }
    }

}
