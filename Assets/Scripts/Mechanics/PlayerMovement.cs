using UnityEngine;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Movement/Player Movement")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables
        [Header("Reference Variables")]

        [SerializeField] private Transform checkGrounded;
        [SerializeField] private LayerMask ground;
        [SerializeField, Range(1f, 20f)] private float jumpForce = 7;
        [SerializeField, Range(0.01f, 2f)] private float checkGroundedRadius = 0.05f;

        [SerializeField, Range(1f, 3f), Tooltip("Multiply gravity by this amount when player has reached the highest point of the jump so that it falls faster and feels less floaty.")]
        private float falling = 2.5f;

        [SerializeField, Range(1f, 3f), Tooltip("Multiply gravity by this amount when the jump key is tapped lightly to have the player jump less high.")]
        private float lowJump = 2f;

        private bool isGrounded = false;
        private PlayerState state;
        private Rigidbody2D rigidBody;
        private PlayerStats stats; //need access to move speed
        #endregion

        #region Properties
        public PlayerState State //makes private state readable
        {
            get => state;
        }
        #endregion

        #region Start
        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>(); //connect rigidbody
            stats = GetComponent<PlayerStats>(); //connect to stats script
        }
        #endregion

        #region Update
        private void Update()
        {
            Move(); //call move function

        }
        private void FixedUpdate()
        {
            //in fixed update bc don't need to call every frame?
            CheckState(); //call function to check state of player

        }
        #endregion

        #region Functions
        #region Movement
        /// <summary>
        /// Calls the movement calculation functions and then moves the player accordingly.
        /// </summary>
        void Move()
        {
            CheckGrounded(); //call check grounded
            AirTime(); //call y movement check

            //move horizontally according to player speed and jump/fall
            rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * stats.Stats.moveSpeed, rigidBody.velocity.y);
        }
        /// <summary>
        /// Checks if the player is grounded byt overlapping a circle collided under the player.
        /// </summary>
        void CheckGrounded()
        {
            //some collider overlapping
            Collider2D collider = Physics2D.OverlapCircle(checkGrounded.position, checkGroundedRadius, ground);
            if (collider != null) //if there is an overlapping collider
            {
                isGrounded = true; //player is grounded
            }
            else //if there is no collider overlapping
            {
                isGrounded = false; //player is in the air
            }
        }
        /// <summary>
        /// Calculates y movement.
        /// Player can jump if grounded.
        /// Player falls faster than it jumps.
        /// Player can jump high (default) or low (light tap on the space bar).
        /// </summary>
        void AirTime()
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded) //if pressing space bar and grounded
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce); //jump
            }
            if (rigidBody.velocity.y < 0) //if y velocity is negative, ie if falling
            {
                rigidBody.velocity += Vector2.up * Physics2D.gravity * (falling - 1) * Time.deltaTime; //fall faster
            }
            else if (rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) //if jumping and jump key is not being held
            {
                rigidBody.velocity += Vector2.up * Physics2D.gravity * (lowJump - 1) * Time.deltaTime; //jump lower
            }
        }
        #endregion
        #region State
        /// <summary>
        /// Assigns state to player based on current movement.
        /// </summary>
        void CheckState()
        {
            if (stats.Stats.healthCurrent <= 0) //if no health
            {
                state = PlayerState.Dead; //change state to dead
            }
            else if (isGrounded) //if on ground
            {
                if (rigidBody.velocity.x == 0) //if not moving
                {
                    state = PlayerState.Idle; //change state to idle
                }
                else //if moving
                {
                    state = PlayerState.Running; //change state to running
                }
            }
            else if (rigidBody.velocity.y > 0) //if jumping
            {
                state = PlayerState.Jumping; //change state to jumping
            }
            else if (rigidBody.velocity.y < 0) //if falling
            {
                state = PlayerState.Falling; //change state to falling
            }
        }
        #endregion
        #endregion
    }
}