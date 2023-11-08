using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    #region Contadores de vida y escudo
    [SerializeField]
    private TextMeshProUGUI healthCount;
    [SerializeField]
    private TextMeshProUGUI shieldCount;
    #endregion

    #region Unidades de vida manejadas
    [SerializeField]
    private float healthCountStart = 100f;
    [SerializeField]
    private float shieldCountStart = 100f;
    private float healthCounter;
    private float shieldCounter;
    private float healthCounterUpdate;
    #endregion

    private void Start()
    {
        //Registrando los niveles de vida asignados en el editor
        healthCounter = healthCountStart;
        shieldCounter = shieldCountStart;

        healthCount.text = healthCountStart.ToString();
        shieldCount.text = shieldCountStart.ToString();
    }

    public void damageTaken(float damage)
    {
        if (shieldCounter > 0f)
        {
            shieldCounter -= damage;
            shieldCount.text = shieldCounter.ToString();
            this.gameObject.GetComponent<PlayerIcon>().damageChange(damage);
        }
        else if (shieldCounter == 0f)
        {
            healthCounter -= damage;
            healthCounterUpdate = Mathf.Clamp(healthCounter, 0f, 100f);
            healthCount.text = healthCounterUpdate.ToString();
            this.gameObject.GetComponent<PlayerIcon>().damageChange(damage);
        }
    }

}