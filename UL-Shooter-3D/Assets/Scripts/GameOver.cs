using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Thanks;
    private TextMeshProUGUI texto; 

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

    
}
