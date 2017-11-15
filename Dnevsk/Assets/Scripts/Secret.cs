using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
    Character character;
    public GameObject SetActive;
    public GameObject SetDesable;
    public GameObject Audio;

    private void Start()
    {
        character = GetComponent<Character>();
    }

        private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            SetActive.SetActive(true);
            SetDesable.SetActive(false);
            Audio.SetActive(true);
        }
    }
}
