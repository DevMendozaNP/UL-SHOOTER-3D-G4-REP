using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsCounter : MonoBehaviour
{
    public GameObject Thanks;
    private TextMeshProUGUI texto; 
    public float finalPoints;

    void Awake()
    {
        texto = Thanks.GetComponent<TextMeshProUGUI>();
        texto.text = "Muchas gracias por jugar!";
        Time.timeScale = 0;
        //texto.text = "Muchas gracias por jugar!<br>Tu puntaje fue: " + finalPoints;
    }

    void Start()
    {
    }

    void Update()
    {
    }

    public void PointsUpdater(float newPoints)
    {
        finalPoints = finalPoints + newPoints;
        Debug.Log("You got a point!: " + finalPoints);
    }
}
