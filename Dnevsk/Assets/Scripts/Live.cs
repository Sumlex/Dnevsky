using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
    AudioSource Audio;
    private SpriteRenderer sprite;
    CircleCollider2D circle;

    public void Start()
    {
        Audio = GetComponent<AudioSource>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D (Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            
            if (character.Lives == 4 && character.Hearts <2)
            {
                    character.Hearts++;
                    character.Lives = 1;
            }
            else character.Lives++;
            Destroy(sprite);
            Destroy(circle);
            Audio.PlayOneShot(Audio.clip);
        }
    }

}
