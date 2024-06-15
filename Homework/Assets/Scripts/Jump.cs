using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private float jumpForce = 7f;

    private Rigidbody2D rigidBody;

    private bool jump = false;
    public bool Jumps
    {
        get => jump;
        set => jump = value;
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void JumpAction()
    {
        Vector2 jumpVelocity = rigidBody.velocity;
        jumpVelocity.y = jumpForce;
        rigidBody.velocity = jumpVelocity;
    }


    void FixedUpdate() 
    {
        if(isGrounded())
        {
            if (jump) 
            {
                JumpAction();
                animator.SetBool("IsInAir", true);
                jump = false;
            }
            else
                animator.SetBool("IsInAir", false);
        }
        else
            animator.SetBool("IsInAir", true);
    }

    public bool isGrounded()
    {
        Vector3 boxOrigin = transform.position;
        boxOrigin.y -= 1;
        Collider2D[] arr = Physics2D.OverlapCircleAll(boxOrigin, 0.5f);
        foreach (Collider2D c in arr)
        {
            if (c.gameObject.CompareTag("Platform") ||
                c.gameObject.CompareTag("Enemy"))
            {
                return true;
            }
        }
        
        return false;
    }
}
