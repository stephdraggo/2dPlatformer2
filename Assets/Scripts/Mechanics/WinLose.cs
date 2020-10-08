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
    //public int sparedEnemy;
    //public int killedEnemy;
    public Collider2D starCollider;
    public GameObject winPanel;//, secretWinPanel; 
    //public GameObject secretWin;
    public Text starsCollected;
    
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

    //Secret function for if player spares more enemies than killed
    /*public void SecretWin()
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

        starsCollected.text = "Extra Stars" + starCount;
    }*/

    public void PickUpStar()
    {
        starCount++;
        starsCollected.text = "Stars Collected " + starCount;
    }



    void Start()
    {
        CompleteLevel();
        PickUpStar();
        //SecretWin();
    }


    void Update()
    {
        
    }
}
