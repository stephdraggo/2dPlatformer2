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

        [SerializeField] private EnemyStats stats;

        [SerializeField, Tooltip("Patrol sequence based on spawner. Will only have two entries currently.")]
        private Vector2[] patrolSequence;
        private Vector2 currentPatrolTarget;

        [SerializeField, Range(0.1f, 5f), Tooltip("The range for seeing the player.")]
        private float sightRange;

        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer render;
        [SerializeField] private float timeState = 5;
        [SerializeField] private float addSpeed=2,closeEnough=1;

        Vector2 target;
        float timer = 0;
        #endregion

        #region Start
        private void Start()
        {


            player = GameObject.FindGameObjectWithTag("Player"); //find player object and connect

            spawner = GetComponentInParent<Spawner>(); //connect parent spawner

            patrolSequence = spawner.PatrolPoints; //get patrol sequence from spawner

            state = EnemyState.Idle; //enemies start Idle

            gameObject.tag = "Enemy"; //tag as enemy

            animator = gameObject.GetComponent<Animator>(); //connect animator

            render = gameObject.GetComponent<SpriteRenderer>(); //connect renderer

            stats = gameObject.GetComponent<EnemyStats>(); //connect stats
        }
        #endregion

        #region Update
        private void Update()
        {
            ChooseMove(); //call move function
        }
        private void FixedUpdate()
        {
            target = new Vector2(player.transform.position.x, player.transform.position.y);
            RaycastHit2D hit = Physics2D.Raycast(target, transform.position, sightRange);
            Debug.Log("tag of object hit with raycast: " + hit.collider.gameObject.tag);

            if (hit.collider != null && hit.collider.gameObject.tag == "Player")
            {
                state = EnemyState.Chase;
            }
            else if (state == EnemyState.Chase)
            {
                state = EnemyState.Idle;
                stats.stats.moveSpeed -= addSpeed; //slow down
            }
        }
        #endregion

        #region Functions
        /// <summary>
        /// move towards given vector2
        /// </summary>
        /// <param name="_target">vector2 target</param>
        private void Move(Vector2 _target)
        {
            _target = new Vector2(_target.x, transform.position.y); //don't move on y axis
            transform.position = Vector2.MoveTowards(transform.position, _target, stats.stats.moveSpeed * Time.deltaTime);
        }
        private void ChooseMove()
        {
            switch (state)
            {
                case EnemyState.Idle:
                    IdleMove();
                    break;


                case EnemyState.Wander:
                    WanderMove();
                    break;


                case EnemyState.Chase:
                    ChaseMove();
                    break;


                default:
                    break;
            }
        }
        private void StateTimer(EnemyState _state)
        {
            timer += Time.deltaTime; //add to timer
            if (timer >= timeState) //if timer reached
            {
                state = _state; //change state
            }
        }
        private void IdleMove()
        {
            if (!animator.GetBool("Idle")) //if animator not idle
            {
                animator.SetBool("Idle", true); //set to idle
                timer = 0;
            }

            StateTimer(EnemyState.Wander); //change to wander after a time

            Move(transform.position); //no movement
        }
        private void WanderMove()
        {
            if (animator.GetBool("Idle")) //if animator idle
            {
                animator.SetBool("Idle", false); //set to not idle
            }

            StateTimer(EnemyState.Idle); //change to idle after a time

            #region choose patrol target
            //if close enough to current target, switch target
            if(Vector2.Distance(transform.position,currentPatrolTarget) <= closeEnough)
            {
                if (currentPatrolTarget == patrolSequence[0])
                {
                    currentPatrolTarget = patrolSequence[1];
                }
                else
                {
                    currentPatrolTarget = patrolSequence[0];
                }
            }
            #endregion

            Move(currentPatrolTarget); //move towards current patrol target
        }
        private void ChaseMove()
        {
            if (animator.GetBool("Idle")) //if animator idle
            {
                animator.SetBool("Idle", false); //set to not idle
                stats.stats.moveSpeed += addSpeed; //faster
            }

            Move(target); //move towards player
        }
        #endregion
    }
}