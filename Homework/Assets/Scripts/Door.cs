using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Sprite doorOpen;
    public Sprite doorClose;

    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && 
            collision.GetComponent<KeyPickup>().keysCollected == 3)
            FindAnyObjectByType<GameEndConditions>().EndGame();
    }
}
