using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] HealthScript playerHealth;
    
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start() 
    {
        healthSlider.maxValue = playerHealth.Health();
    }

    void Update() 
    {
        healthSlider.value =  playerHealth.Health();
        scoreText.text = scoreKeeper.GetScore().ToString("00000000");   
    }
}
