using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Life/Spider")]
    public class EnemyStats : Life
    {
        #region Variables
        [Header("Life Variables")]
        public LifeStats stats;
        #endregion

        #region Start
        private void Start()
        {
            stats.moveSpeed = Random.Range(0.01f, 1f);
        }
        #endregion

        #region Update
        private void Update()
        {
            if (stats.healthCurrent <= 0)
            {
                Die();
            }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Take an amount of damage from the health.
        /// </summary>
        /// <param name="damage">float amount of damage</param>
        private void TakeDamage(float damage)
        {
            stats.healthCurrent -= damage;
        }
        private void Die()
        {
            WinLose.enemyCheck.RemoveAt(0);
            //animations
            Destroy(gameObject);
        }
        #endregion
    }
}