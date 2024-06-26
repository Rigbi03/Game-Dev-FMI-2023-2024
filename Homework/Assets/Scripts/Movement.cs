using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;

    float horizontal;

    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = 0;
        //speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        if(gameObject.GetComponent<Jump>().isGrounded())
            animator.SetFloat("Speed", Mathf.Abs(horizontal * speed));
    }
    void FixedUpdate(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(horizontal * speed,rb.velocity.y);

        if(rb.position.y < -10)
        {
            FindObjectOfType<GameEndConditions>().Restart();
        }
    }
    
}
