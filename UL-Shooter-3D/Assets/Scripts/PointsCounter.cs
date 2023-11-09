using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PointsCounter : MonoBehaviour
{
    public GameObject Counter;
    private TextMeshProUGUI texto; 
    public float finalPoints = 0f;

    // Start is called before the first frame update
    void Start()
    {
        texto = Counter.GetComponent<TextMeshProUGUI>();
        texto.text = finalPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = finalPoints.ToString();
    }

    public void PointsUpdater(float newPoints)
    {
        finalPoints = finalPoints + newPoints;
        Debug.Log("You got a point!: " + finalPoints);
    }
}
