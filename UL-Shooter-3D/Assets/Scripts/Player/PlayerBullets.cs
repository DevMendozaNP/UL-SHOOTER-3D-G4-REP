using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerBullets : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private TextMeshProUGUI bulletCount;
    
    private float bulletCounter = 100f;

    private void Start()
    {
        bulletCount.text = bulletCounter.ToString();
    }

    private void Update()
    {
        bulletCount.text = bulletCounter.ToString();
    }

    public void bulletUpdater(float bulletInfo)
    {
        bulletCounter = bulletInfo;
    }
}
