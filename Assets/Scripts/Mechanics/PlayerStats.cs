using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Life/Player Stats")]
    public class PlayerStats : Life
    {
        #region Variables
        [Header("Life Variables")]
        [SerializeField] private LifeStats stats;
        public HealthDisplay healthDisplay;

        private PlayerMovement player;
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
            player = GetComponent<PlayerMovement>(); //connect player movement script
            healthDisplay.UpdateHearts(Stats.healthCurrent, Stats.healthMax); //display hearts according to health if loading in with injuries
        }
        #endregion

        #region Update
        private void Update()
        {
            if (Stats.healthCurrent <= 0) //if no health
            {
                Death(); //call death function
            }


#if UNITY_EDITOR
            //debug commands does not make it into the build, only functional in unity
            DebugCommands();
#endif
        }
        private void LateUpdate()
        {
            HealthBounds(); //keep health between 0 and max

            healthDisplay.UpdateHearts(Stats.healthCurrent, Stats.healthMax); //update health display
        }
        #endregion

        #region Collisions and Triggers
        private void OnTriggerEnter2D(Collider2D collider)
        {
            #region instant death collision
            if (collider.tag == "InstantDeath") //if collided with an instant death object
            {
                stats.healthCurrent = 0; //health set to 0
            }
            #endregion
            #region enemy collision
            else if (collider.tag == "Enemy") //if collided with enemy object
            {
                //takes care of if the object got mistagged
                collider.TryGetComponent<SpiderStats>(out SpiderStats enemy);
                if (enemy != null) //if there is a stats script on the object
                {
                    if (player.State == PlayerState.Falling) //if falling
                    {
                        Damage(stats.attackDamage, enemy); //call damage to enemy
                    }
                    else //if not falling
                    {
                        Damage(enemy.stats.attackDamage); //call damage to default (player)
                    }
                }
            }
            #endregion
        }
        #endregion

        #region Functions
        /// <summary>
        /// Keeps health between 0 and max health value.
        /// </summary>
        private void HealthBounds()
        {
            if (Stats.healthCurrent > Stats.healthMax) //if health is more than max health
            {
                stats.healthCurrent = Stats.healthMax; //set back to max
            }
            else if (Stats.healthCurrent < 0) //if health is negative
            {
                stats.healthCurrent = 0; //set to 0
            }
        }
        /// <summary>
        /// Damage the player (default) or an object with spider stats.
        /// </summary>
        /// <param name="damage">damage float</param>
        /// <param name="spider">optional spider stats script</param>
        private void Damage(float damage, SpiderStats spider = null)
        {
            if (spider != null) //if spider
            {
                spider.stats.healthCurrent -= damage; //damage spider
            }
            else //if player
            {
                stats.healthCurrent -= damage; //damage player
            }
        }
        private void Death()
        {
            Debug.Log("Died.");
        }
        #endregion

        #region UNITY_EDITOR
#if UNITY_EDITOR
        /// <summary>
        /// Press X to damage player.
        /// </summary>
        private void DebugCommands()
        {
            //press X to damage player
            if (Input.GetKeyDown(KeyCode.X))
            {
                stats.healthCurrent -= 1; //damage amount
                healthDisplay.UpdateHearts(stats.healthCurrent, stats.healthMax); //display
            }
        }
#endif
        #endregion
    }
}