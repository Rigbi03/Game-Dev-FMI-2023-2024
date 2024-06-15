using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField]
    public Sprite[] foliageSprites;

    void Start()
    {
        SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();   
        int spriteIndex = Random.Range(0, foliageSprites.Length);
        spriterenderer.sprite = foliageSprites[spriteIndex];
    }
}
