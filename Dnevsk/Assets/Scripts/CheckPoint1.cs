using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{
    Character character;
    public GameObject Audio;
    public GameObject Chpt;
    public GameObject Chpoint;
    public GameObject ChpointAudio;

    private void Start()
    {
        character = GetComponent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            ChpointAudio.SetActive(false);
            Chpoint.SetActive(false);
            Chpt.SetActive(true);
            Audio.SetActive(true);
        }
    }
}
