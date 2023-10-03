using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArkanoidManager : MonoBehaviour
{
    public static ArkanoidManager instance;
    public TextMeshProUGUI scoreText;
    public float score;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = "x" + score;
    }

    public void AddScore(float amount)
    {
        score += amount;
        scoreText.text = "x" + score;
    }
}
