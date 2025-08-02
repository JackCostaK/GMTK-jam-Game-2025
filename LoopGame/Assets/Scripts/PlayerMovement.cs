using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls player movement and animation.
/// </summary>
public class PlayerCtrl : MonoBehaviour
{
    // Public variables to be set in the Unity Inspector.
    public Animator animator;
    public float speed;

    // Private variables for internal use.
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private PickUp pickUp;

    /// <summary>
    /// Start is called before the first frame update.
    /// This is a good place to get references to other components.
    /// </summary>
    void Start()
    {
        // Get a reference to the Rigidbody2D component.
        rb = GetComponent<Rigidbody2D>();

        // Get a reference to the PickUp component.
        // It's crucial that this component is on the same GameObject as PlayerCtrl.
        pickUp = GetComponent<PickUp>();

        // Check if the PickUp component was found. This prevents the NullReferenceException.
        if (pickUp != null)
        {
            // Initialize the direction for the PickUp script.
            // This is a good practice to ensure it has a valid state from the beginning.
            pickUp.Direction = new Vector2(0, -1);
        }
        else
        {
            // Log an error if the PickUp component is missing.
            // This makes debugging much easier.
            Debug.LogError("PickUp component not found on the GameObject. Please attach it to the same GameObject as PlayerCtrl.");
        }
    }

    /// <summary>
    /// Update is called once per frame. This is where we handle input.
    /// </summary>
    void Update()
    {
        // Get raw input for horizontal and vertical movement.
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Set the player's velocity directly based on input and speed.
        // Using `rb.velocity` in Update() is fine for non-physics-based movement.
        rb.velocity = moveInput.normalized * speed;

        // Check if the player is moving.
        if (moveInput.sqrMagnitude > 0.1f)
        {
            // If the PickUp component exists, update its direction.
            if (pickUp != null)
            {
                pickUp.Direction = moveInput.normalized;
            }

            // Set animation parameters based on the direction of movement.
            // We use a single `moveInput` vector to handle all four directions more cleanly.
            animator.SetBool("IsWalking", true);
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
        }
        else
        {
            // If the player is not moving, stop the walking animation.
            animator.SetBool("IsWalking", false);
        }
    }
}
