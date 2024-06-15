using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Animator animator;
    public CameraShake cameraShake;
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Material lowHealthMaterial;

    private void Update()
    {

        if (health > 3)
            health = 3;

        if(health < 1)
        {
            FindObjectOfType<GameEndConditions>().Restart();
        }

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
            if (this.GetComponent<PowerUp>().hasSmash)
            {
                collision.gameObject.GetComponent<Animator>().SetBool("IsDead", true);
                Debug.Log("Enemy Killed!");
            }
            else
            {
                StartCoroutine(cameraShake.Shake(.15f, .4f));
                health--;
            }
        }
    }


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (health == 1)
        {
            Graphics.Blit(source, destination, lowHealthMaterial);
            return;
        }
        Graphics.Blit(source, destination);
    }
}
