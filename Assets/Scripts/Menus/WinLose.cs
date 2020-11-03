﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    //For checking how many enemies are left after all stars are collected (trigger bonus level)
    public static List<Mechanics.EnemyMovement> enemyCheck = new List<Mechanics.EnemyMovement>();
    public MusicHandler music;

    #region VARIABLES
    [Header("Collectables")]
    public int starCount = 0; //current stars collected
    public int requiredStarCount = 10; //stars needed to finish the level
    public Text starsCollected;

    [Header("Panels")]
    public Collider2D starCollider;
    public GameObject winPanel, bonusLevelPanel, HUD;

    [Header("Enemy Variables")]
    public int sparedEnemyCount; //how many enemies need to be spared to get bonus level
    public int sparedEnemy; //how many enemies have been spared
    public int killedEnemy; //how many enemies have been killed

    public int totalEnemies;
    #endregion

    #region Functions
    //Function for completing the level and moving onto the next level
    public void CompleteLevel()
    {
        //If you collect all stars = win!
        if (starCount >= requiredStarCount)
        {

            if (enemyCheck.Count >= totalEnemies / 2)
            {
                bonusLevelPanel.SetActive(true);
                winPanel.SetActive(false);
            }
            else
            {
                winPanel.SetActive(true);
                bonusLevelPanel.SetActive(false);
                
            }
        }
    }

    #region BONUS LEVEL
    //If player collects all the stars without killing the spiders then BONUS LEVEL OF STARS in cave appears
    //Look for list of enemies and check how many are left after all stars are collected
    public void BonusLevel()
    {
        if (sparedEnemy >= sparedEnemyCount && starCount >= requiredStarCount)
        {
            bonusLevelPanel.SetActive(true);
            winPanel.SetActive(false);
            HUD.SetActive(false);
            music.StarFX();
        }
        else if (sparedEnemy <= killedEnemy)
        {
            bonusLevelPanel.SetActive(false);
        }
        
    }

    #endregion

    //Function for being able to pick up the stars and the text updating on screen
    public void PickUpStar()
    {
        starCount++;
        starsCollected.text = "Stars Collected " + starCount;
    }

    void Start()
    {
        
    }


    void Update()
    {
        CompleteLevel();
        BonusLevel(); 
    }
    #endregion
}
