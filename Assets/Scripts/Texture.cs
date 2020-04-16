using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture : MonoBehaviour
{
    [SerializeField] List<Sprite> textures = new List<Sprite>();
    SpriteRenderer spriteR;

     void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = GetRandomSprite();
        //Debug.Log("Texture name " + spriteR.sprite.name);
    }

    Sprite GetRandomSprite()
    {
        int randomNum = Random.Range(0, textures.Count);
        return textures[randomNum];
    }
}
