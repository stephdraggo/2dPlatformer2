using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    #region VARIABLES
    [Header("Collectables")]
    public int starCount = 0; //current stars collected
    public int finishStarCount = 10; //stars needed to finish the level
    public Text starsCollected;

    [Header("Panels")]
    public Collider2D starCollider;
    public GameObject winPanel, secretWinPanel;

    //[Header("Enemy Variables")]
    //public int sparedEnemyCount; //how many enemies need to be spared to get secret win
    //public int sparedEnemy; //how many enemies have been spared
    //public int killedEnemy; //how many enemies have been killed
    #endregion
    //Function for completing the level and moving onto the next level
    public void CompleteLevel()
    {
        Debug.Log(gameObject);
        //If stars collected is greater or equal to finished star count, then the congrats menu pops up
        if (starCount >= finishStarCount)
        {
            Debug.Log("get enough stars");
            winPanel.SetActive(true);
        }
    }

    #region TEST SECRET WIN
    /*Secret function for if player spares more enemies than killed THIS IS BEING TESTED
    public void SecretWin()
    {
        if (sparedEnemy >= killedEnemy)
        {
            secretWinPanel.SetActive(true);
            finishStarCount *= 2; //End star count multiplied by 2 
        }
        else if (sparedEnemy <= killedEnemy)
        {
            secretWinPanel.SetActive(false);
            finishStarCount /= 2; //Final star count divided by 2 (TEST)
        }
        //Text UI to show how many extra stars received 
        starsCollected.text = "Extra Stars" + starCount;
    }
    */
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
        //SecretWin(); (TEST)
    }
}
