using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    //For checking how many enemies are left after all stars are collected (trigger bonus level)
    public static List<Mechanics.EnemyMovement> enemyCheck = new List<Mechanics.EnemyMovement>(); 


    #region VARIABLES
    [Header("Collectables")]
    public int starCount = 0; //current stars collected
    public int requiredStarCount = 10; //stars needed to finish the level
    public Text starsCollected;

    [Header("Panels")]
    public Collider2D starCollider;
    public GameObject winPanel, bonusLevelPanel;

    [Header("Enemy Variables")]
    public int sparedEnemyCount; //how many enemies need to be spared to get bonus level
    public int sparedEnemy; //how many enemies have been spared
    public int killedEnemy; //how many enemies have been killed
    #endregion

    #region Functions
    //Function for completing the level and moving onto the next level
    public void CompleteLevel()
    {
        //If stars collected is greater or equal to finished star count and if amount of enemies spared is greater than or equal to required enemies spared 
        //==BONUS LEVEL
        if (starCount >= requiredStarCount && killedEnemy == 0)
        {
            winPanel.SetActive(true);
        }
    }

    #region TEST BONUS LEVEL
    //If player collects all the stars without killing the spiders then BONUS LEVEL OF STARS in cave appears
    //Look for list of enemies and check how many are left after all stars are collected
    public void BonusLevel()
    {
        SceneManager.LoadScene();

        /*if (sparedEnemy >= sparedEnemyCount)
        {
            
            //bonusLevelPanel.SetActive(true);
            
        }
        else if (sparedEnemy <= killedEnemy)
        {
            bonusLevelPanel.SetActive(false);
        }*/
        

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
        BonusLevel(); //TEST
    }
    #endregion
}
