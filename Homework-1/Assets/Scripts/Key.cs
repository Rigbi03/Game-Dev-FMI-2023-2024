using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Key Collected!");
            Destroy(this.gameObject);
        }
    }
}
