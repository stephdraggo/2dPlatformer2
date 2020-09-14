using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Movement/Enemy")]
    public class EnemyMovement : MonoBehaviour
    {
        #region Variables
        private EnemyState state;
        #endregion

        #region Start
        private void Start()
        {
            state = EnemyState.Passive;
        }
        #endregion

        #region Update
        private void Update()
        {

        }
        #endregion

        #region Functions

        #endregion
    }
}