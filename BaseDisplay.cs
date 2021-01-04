using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BaseDisplay : MonoBehaviour
{

    [SerializeField] float baseHP = 11f;
    float lives;
    Text baseHPText;

    
    

    void Start()
    {
        lives = baseHP - PlayerPrefsController.GetDifficulty();
        baseHPText = GetComponent<Text>();
        UpdateDisplay();

    }

    
    private void UpdateDisplay()
    {
        baseHPText.text = lives.ToString();
    }

    public void LoseHealth()
    {
        if (lives > 0f)
        {
            lives -= 1f;
            UpdateDisplay();
        }

        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }

    }
}
