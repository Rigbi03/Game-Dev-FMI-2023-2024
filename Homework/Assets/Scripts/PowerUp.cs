using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool hasSmash = false;

    public void SetSmash(bool state)
    {
        hasSmash=state;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Power-Up"))
        {
            hasSmash = true;
            Debug.Log("Power Collected!");
            Destroy(collision.gameObject);
        }
    }
}
