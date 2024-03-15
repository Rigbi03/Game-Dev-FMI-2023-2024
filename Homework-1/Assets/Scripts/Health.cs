using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Animator animator;
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {

        if (health > 3)
            health = 3;

         for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else hearts[i].sprite = emptyHeart;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("WasHurt", true);
            health--;
            animator.SetBool("WasHurt", false);
        }
    }
}
