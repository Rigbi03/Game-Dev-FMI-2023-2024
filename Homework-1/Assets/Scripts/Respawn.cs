using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject respawnPoint;
    [SerializeField] LayerMask respawnLayer;


    /*Vector2 startposition;

    private void Start()
    {
        startposition.x = -8;
        startposition.y = 0;
    }

   */
    private void FixedUpdate()
    {
        if(this.transform.position.y < -10)
        {
            transform.position = respawnPoint.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(((1 << col.gameObject.layer) & respawnLayer.value) != 0)
        {
            transform.position = respawnPoint.transform.position;
        }
    }
}
