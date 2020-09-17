using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    [AddComponentMenu("Mechanics/Movement/Player")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables
        [Header("Reference Variables")]

        [SerializeField] private Transform checkGrounded;
        [SerializeField] private LayerMask ground;
        [SerializeField, Range(1f, 7f)] private float speed = 4;
        [SerializeField, Range(4f, 10f)] private float jumpForce = 7;
        [SerializeField, Range(0.01f, 2f)] private float checkGroundedRadius = 0.05f;
        [SerializeField] private float fallMultiplier=2.5f, lowJumpMultiplier=2f;

        private bool isGrounded = false;
        private PlayerState state;
        private Rigidbody2D rigidBody;
        #endregion

        #region Start
        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>(); //connect rigidbody
        }
        #endregion

        #region Update
        private void Update()
        {
            CheckGrounded();
            Move();

        }
        #endregion

        #region Functions
        void Move()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            }
            rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rigidBody.velocity.y);
        }
        void CheckGrounded() //comment this
        {
            Collider2D collider = Physics2D.OverlapCircle(checkGrounded.position, checkGroundedRadius, ground);
            if (collider != null)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        void BetterJump() //understand and comment this
        {
            if (rigidBody.velocity.y < 0)
            {
                rigidBody.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                rigidBody.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        #endregion
    }
}