using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject winPanel;
    public GameObject secretWin;

    public void CompleteLevel()
    {
        //If stars collected is greater or equal to finished star count, then the congrats menu pops up
        if (starCount >= finishStarCount)
        {
            winPanel.SetActive(true);
        }
    }

    //Secret function for if player spares more enemies than killed
    public void SecretWin()
    {
        if (sparedEnemy >= killedEnemy)
        {
            secretWin.SetActive(true);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
