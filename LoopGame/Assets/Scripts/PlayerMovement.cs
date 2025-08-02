using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Animator animator;
    public float speed;
    float speedX, speedY;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector2(speedX, speedY);

        if(speedY != 0){
            animator.SetBool("IsWalkingUp", true);
            print("Up");
        }
        else if(speedX < 0){
            animator.SetBool("IsWalkingLeft", true);

        }
        else if(speedX > 0){
            animator.SetBool("IsWalkingRight", true);
            print("Right");
        }
        else{
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingUp", false);
        }

    }
}