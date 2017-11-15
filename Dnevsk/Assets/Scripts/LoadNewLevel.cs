using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewLevel : MonoBehaviour
{
    public GameObject Start;
    public GameObject Level;
    public GameObject Loader;

    public void Update()
    {
        if (Start.activeSelf == true && Input.GetButtonDown("Jump"))
        {
            Start.SetActive(false);
            Level.SetActive(true);
            Loader.SetActive(false);
        }
    }
}
