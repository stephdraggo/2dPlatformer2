using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Life/Player")]
    public class PlayerStats : Life
    {
        #region Variables
        [Header("Life Variables")]
        [SerializeField] private LifeStats stats;
        public HealthDisplay healthDisplay;
        #endregion
        #region Properties
        public LifeStats Stats
        {
            get
            {
                return stats;
            }
            set
            {
                stats = value;

                healthDisplay.UpdateHearts(value.healthCurrent, value.healthMax); //update the heart display when health changes
            }
        }
        #endregion

        #region Start
        private void Start()
        {
            healthDisplay.UpdateHearts(stats.healthCurrent, stats.healthMax);
        }
        #endregion

        #region Update
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                stats.healthCurrent -= 1;
                healthDisplay.UpdateHearts(stats.healthCurrent, stats.healthMax);
            }
        }
        private void LateUpdate()
        {
            if (stats.healthCurrent > stats.healthMax)
            {
                stats.healthCurrent = stats.healthMax;
            }
            else if (stats.healthCurrent < 0)
            {
                stats.healthCurrent = 0;
                Debug.Log("Die.");
            }
        }
        #endregion

        #region Functions

        #endregion
    }
}