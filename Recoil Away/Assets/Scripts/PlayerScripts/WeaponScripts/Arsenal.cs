using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arsenal : MonoBehaviour
{
    SpriteRenderer weaponSprite;

    public Sprite[] weaponArsenal = new Sprite[5];

    void Start()
    {
        weaponSprite = gameObject.GetComponent<SpriteRenderer>();

        weaponSprite.sprite = weaponArsenal[0];

        //Resize weapons
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    void Update()
    {
        
    }
}
