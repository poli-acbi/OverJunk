using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// NOTE: The movement for this script uses the new InputSystem. The player needs to have a PlayerInput
// component added and the Behaviour should be set to Send Messages so that the OnMove and OnFire methods
// actually trigger

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    private Vector2 moveInput;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private Rigidbody2D rb;
    private Animator animator;

    //   [SerializeField] private UI_Inventory uiInventory;
    //private Inventory inventory;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //private void Awake()
    //{
        //inventory = new Inventory();
        //uiInventory.SetInventory(inventory);

        //ItemWorld.SpawnItemWorld(new Vector3(20, 20), new Item { itemType = Item.ItemType.Food, amount = 1});
    //}

    public void FixedUpdate()
    {

        rb.MovePosition(rb.position + (moveInput * moveSpeed * Time.fixedDeltaTime));

        if (moveInput != Vector2.zero)
        {
            // Try to move player in input direction, followed by left right and up down input if failed
            bool success = MovePlayer(moveInput);

            if (!success)
            {
                // Try Left / Right
                success = MovePlayer(new Vector2(moveInput.x, 0));

                if (!success)
                {
                    success = MovePlayer(new Vector2(0, moveInput.y));
                }
            }

            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }


    }

    // Tries to move the player in a direction by casting in that direction by the amount
    // moved plus an offset. If no collisions are found, it moves the players
    // Returns true or false depending on if a move was executed
    public bool MovePlayer(Vector2 direction)
    {
        Vector2 desiredPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;

        // Check for collision at the desired position
        Collider2D[] hits = new Collider2D[1]; // Array to store collision information
        ContactFilter2D contactFilter = new ContactFilter2D(); // Customize this filter if needed

        if (rb.OverlapCollider(contactFilter, hits) > 0)
        {
            // Collision detected
            print("Collision detected");
            // You can perform collision-related actions here
            return false; // Movement wasn't successful due to collision
        }

        // No collision detected, move the player
        rb.MovePosition(desiredPosition);
        return true; // Movement successful
    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        // Only set the animation direction if the player is trying to move
        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("XInput", moveInput.x);
            animator.SetFloat("YInput", moveInput.y);
        }
    }

    public void OnFire()
    {
        print("Shots fired");
    }
}
 

