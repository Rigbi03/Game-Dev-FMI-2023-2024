using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public int keysCollected;
    public Image[] keys;
    public Sprite collectedKey;
    public Sprite notCollectedKey;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            keys[keysCollected].sprite = collectedKey;
            keysCollected++;
        }
    }

}
