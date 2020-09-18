using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Life/Base")]
    public class Life : MonoBehaviour
    {
        #region Variables
        /// <summary>
        /// Stat types shared by player and enemies.
        /// Inheriting classes will have their own copies of these stats.
        /// healthCurrent, healthMax, moveSpeed, attackDamage & attackSpeed
        /// </summary>
        [System.Serializable]
        public struct LifeStats
        {
            public float healthCurrent;
            public float healthMax;
            public float moveSpeed;
            public float attackDamage;
            public float attackSpeed;
        }
        #endregion
    }
}