using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Spawner")]
    public class Spawner : MonoBehaviour
    {
        #region Variables
        [SerializeField, Tooltip("The enemy type to spawn here")]
        private GameObject enemyPrefab;

        [SerializeField, Tooltip("The bounds for the enemies patrol.")]
        private Transform leftBound,rightBound;

        [SerializeField, Range(1, 10), Tooltip("The number of living enemies allowed at this spawner at one time.")]
        private int spawnNumber = 1;

        [SerializeField, Tooltip("List of current living enemies in this spawner.")]
        private List<GameObject> children;

        [SerializeField, Range(0f, 5f), Tooltip("Cooldown for spawning new children.")]
        private float spawnTimer = 0;
        #endregion

        #region Properties
        
        #endregion

        #region Start
        private void Start()
        {
            for (int i = 0; i < spawnNumber; i++) //up to the max allowed enemies
            {
                SpawnNewEnemy(); //spawn children
            }
        }
        #endregion

        #region Update
        private void Update()
        {
            //if in view of minimap
            //enable children
            //else
            //disable children

            if (children.Count < spawnNumber) //if does not have max children
            {

                //add timer/countdown
                SpawnNewEnemy(); //spawn new child
            }
        }
        #endregion

        #region Functions
        public Transform[] PatrolSequence()
        {
            return null;
        }
        private void SpawnNewEnemy()
        {

            GameObject newEnemy= Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform); //summon enemy
            WinLose.enemyCheck.Add(newEnemy.GetComponent<EnemyMovement>());
            children.Add(newEnemy);
        }
        #endregion
    }
}