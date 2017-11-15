using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame: MonoBehaviour
{
    public GameObject MainMovie;
    public GameObject Load;
    public MovieTexture Movie;


    private void Start()
    {
        Movie.Play();

    }
    public void Update()
    {
        if (Movie.isPlaying == false || Input.GetButtonDown("Jump"))
        {
            MainMovie.SetActive(false);
            Load.SetActive(true);        }
    }
}
