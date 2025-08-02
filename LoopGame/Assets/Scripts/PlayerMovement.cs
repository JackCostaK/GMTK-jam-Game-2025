using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Animator animator;
    public float speed;
    float speedX, speedY;
    Rigidbody2D rb;
    private Vector3 Change;
    private PickUp PickUp;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PickUp = gameObject.GetComponent<PickUp>();
        PickUp.Direction = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        Change = Vector3.zero;
        Change.x = Input.GetAxisRaw("Horizontal");
        Change.y = Input.GetAxisRaw("Vertical");
        if(Change.sqrMagnitude > .1f)
        {
            PickUp.Direction = Change.normalized;       
        }

        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector2(speedX, speedY);

        if (speedY != 0)
        {
            animator.SetBool("IsWalkingUp", true);
            print("Up");
        }
        else if (speedX < 0)
        {
            animator.SetBool("IsWalkingLeft", true);
            print("Left");

        }
        else if (speedX > 0)
        {
            animator.SetBool("IsWalkingRight", true);
            print("Right");
        }
        else
        {
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingUp", false);
        }

    }
}

