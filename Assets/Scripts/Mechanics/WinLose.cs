using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    /*Score
            * game score
                -stars collected
                -enemies killed/spared?

            * temp(level) score
                -discard if level failed
                -add to game score if level succeeded
    */

    public int starCount = 0; //current stars collected
    public int finishStarCount = 10; //stars needed to finish the level
    public int sparedEnemy;
    public int killedEnemy;
    public Collider2D starCollider;
    public GameObject winPanel, losePanel;
    public GameObject secretWin;
    public Text starsCollected;
    
    public void CompleteLevel()
    {
        //If stars collected is greater or equal to finished star count, then the congrats menu pops up
        if (starCount >= finishStarCount)
        {
            winPanel.SetActive(true);
        }
        else if (starCount <= finishStarCount)
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false);
        }
    }

    //Secret function for if player spares more enemies than killed
    public void SecretWin()
    {
        if (sparedEnemy >= killedEnemy)
        {
            secretWin.SetActive(true);
            finishStarCount *= 2; //End star count multiplied by 2 
        }
    }

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
        
    }
}
