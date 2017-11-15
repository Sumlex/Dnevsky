using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Character character;
    public GameObject Audio;
    public GameObject Chp;
    public GameObject Chpoint1;

    private void Start()
    {
        character = GetComponent<Character>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            Chpoint1.SetActive(false);
            Chp.SetActive(true);
            Audio.SetActive(true);
        }
    }
}
