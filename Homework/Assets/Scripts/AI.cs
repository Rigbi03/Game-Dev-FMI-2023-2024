using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Mathf;

public class AI : MonoBehaviour
{
    public Animator animator;

    Rigidbody2D rb2d;
    float horizontal = -1;

    public Transform player;

    [SerializeField] float speed;

    void Start()
    {
        player = GameObject.Find("Player").transform;

        if (!player)
            player = transform;

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
    }

    private void FixedUpdate()
    {
        if (Abs(transform.position.x - player.position.x) < 1f &&
            player.position.y >= transform.position.y + 3f     &&
            isGrounded())
        {
            AttackPlayer();
            speed = 0f;
            animator.SetBool("IsInAir", true);
            animator.SetFloat("Speed", speed);
        }
        else if (isGrounded())
        {
            animator.SetBool("IsInAir", false);
            speed = 1.5f;
            animator.SetFloat("Speed", speed);
        }
    }

    public void AttackPlayer()
    {
        rb2d.AddForce(transform.up * 2f, ForceMode2D.Impulse);
    }

    public bool isGrounded()
    {
        Vector2 boxOrigin = transform.position;
        boxOrigin.y -= 1;
        Collider2D[] arr = Physics2D.OverlapCircleAll(boxOrigin, 0.01f);
        foreach (Collider2D c in arr)
        {
            if (c.gameObject.CompareTag("Platform"))
            {
                return true;
            }
        }

        return false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        horizontal *= -1;
    }
}
