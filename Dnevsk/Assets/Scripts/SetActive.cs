using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    Character character;
    public GameObject Setactive;

    private void Start()
    {
        character = GetComponent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            Setactive.SetActive(true);
            Destroy(gameObject);
        }
    }
}
