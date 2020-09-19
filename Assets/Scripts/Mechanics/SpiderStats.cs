using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Life/Spider")]
    public class SpiderStats : Life
    {
        #region Variables
        [Header("Life Variables")]
        public LifeStats stats;
        #endregion

        #region Start
        private void Start()
        {

        }
        #endregion

        #region Update
        private void Update()
        {

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
        #endregion
    }
}