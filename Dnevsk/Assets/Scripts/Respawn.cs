using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject CheckPoint;

    public float ResPawnX, ResPawnY;
    Character character;

    public void Start()
    {
        character = GetComponent<Character>();
    }

}
