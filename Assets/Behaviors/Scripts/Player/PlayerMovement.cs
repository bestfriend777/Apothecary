using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float lastKey;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        //Dont need this for movement script
    }

    // Update is called once per frame
    void Update()
    {
        // This method is unreliable for physics because the update rate is variable based on our framerate
        // Time and physics based code should go in a FixedUpdate() method
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.x != 0)
        {
            if(movement.x > 0)
            {
                lastKey = 3.0f;
            }
            else if(movement.x < 0)
            {
                lastKey = 1.0f;
            }
        }
        else
        {
            if (movement.y > 0)
            {
                lastKey = 2.0f;
            }
            else if(movement.y < 0)
            {
                lastKey = 0.0f;
            }
        }

        animator.SetFloat("LastKey", lastKey);
    }

    void FixedUpdate()
    {
        // This is called by default 50x/per second
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
    }
}
