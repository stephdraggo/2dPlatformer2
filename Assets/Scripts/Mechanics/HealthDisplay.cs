using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Life/Player Hearts")]
    public class HealthDisplay : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Image[] heartSlots;
        [SerializeField] private Sprite[] hearts;
        private float healthPerSection;
        #endregion

        #region UpdateHearts
        /// <summary>
        /// Goes through each heart slot and calculates what should be be displayed based on current health.
        /// </summary>
        /// <param name="currentHealth">The current health of the player.</param>
        /// <param name="maxHealth">The max health of the player</param>
        public void UpdateHearts(float currentHealth, float maxHealth)
        {
            int heartSlotIndex = 0;

            healthPerSection = maxHealth / (heartSlots.Length * 4); //calculate how much health each heart slot quarter is worth

            foreach (Image heart in heartSlots)
            {
                if (currentHealth >= healthPerSection * 4 * (heartSlotIndex + 1)) //if current health fills this heart
                {
                    heartSlots[heartSlotIndex].sprite = hearts[4]; //display full heart
                }
                else if (currentHealth >= healthPerSection * (4 * heartSlotIndex + 3)) //if current health reaches at least a 3/4 of the current heart
                {
                    heartSlots[heartSlotIndex].sprite = hearts[3]; //display 3/4 heart
                }
                else if (currentHealth >= healthPerSection * (4 * heartSlotIndex + 2))
                {
                    heartSlots[heartSlotIndex].sprite = hearts[2];
                }
                else if (currentHealth >= healthPerSection * (4 * heartSlotIndex + 1))
                {
                    heartSlots[heartSlotIndex].sprite = hearts[1];
                }
                else
                {
                    heartSlots[heartSlotIndex].sprite = hearts[0];
                }
                heartSlotIndex++;
            }
        }
        #endregion
    }
}