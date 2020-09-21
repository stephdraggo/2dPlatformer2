using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Movement/Enemy")]
    public class EnemyMovement : MonoBehaviour
    {
        #region Variables
        private EnemyState state;
        [SerializeField] private GameObject player;

        [SerializeField] private Spawner spawner;

        [SerializeField, Tooltip("Patrol sequence based on spawner. Will only have two entries currently.")]
        private Transform[] patrolSequence;

        [SerializeField, Range(0.1f, 5f), Tooltip("The range for seeing the player.")]
        private float sightRange;

        Vector2 target;
        float sightDistance = 5;
        #endregion

        #region Start
        private void Start()
        {


            player = GameObject.FindGameObjectWithTag("Player"); //find player object and connect

            spawner = GetComponentInParent<Spawner>(); //connect parent spawner

            patrolSequence = spawner.PatrolSequence(); //get patrol sequence from spawner

            state = EnemyState.Passive; //enemies start passive

            gameObject.tag = "Enemy"; //tag as enemy


        }
        #endregion

        #region Update
        private void Update()
        {
            Move(); //call move function
        }
        private void FixedUpdate()
        {
            target = new Vector2(player.transform.position.x, player.transform.position.y);
            RaycastHit2D hit = Physics2D.Raycast(target, transform.position, sightDistance);
            Debug.Log("tag of object hit with raycast: " + hit.collider.gameObject.tag);

            if (hit.collider != null && hit.collider.gameObject.tag == "Player")
            {
                state = EnemyState.Aggressive;
            }
            else
            {
                state = EnemyState.Passive;
            }
        }
        #endregion

        #region Functions
        private void Move()
        {
            if (state == EnemyState.Passive) //if enemy is in passive state
            {
                PassiveMove(); //call passive movement
            }
            else if (state == EnemyState.Aggressive) //if enemy is in aggressive state
            {
                AggressiveMove(); //call aggressive movement
            }
            else //if enemy does not have a state assigned
            {
                Debug.Log("No state assigned, fix this.");
            }
        }
        private void PassiveMove()
        {
            //slower
            //'patrols' platform
            //animation?
        }
        private void AggressiveMove()
        {
            //faster
            //move towards player
            //animation?
        }
        #endregion
    }
}