using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    

    AudioSource Audio;
    private SpriteRenderer sprite;
    BoxCollider2D box;

    protected virtual void Awake() { }
    protected virtual void Start()
    {
        Audio = GetComponent<AudioSource>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update() { }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();
        Fire fire = collider.GetComponent<Fire>();
        

        if (bullet)
        {
            Destroy(sprite);
            Destroy(box);
            Destroy(gameObject, 0.2f);
            Audio.PlayOneShot(Audio.clip);
        }
    }
}
