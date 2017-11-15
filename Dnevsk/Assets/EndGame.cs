using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour {

    public GameObject mainMovie;
    public MovieTexture moviee;
    public GameObject loader;

    float timer;

    // Use this for initialization
    void Start () {
        moviee.Play();
        timer = 56;
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if (timer <= 0 || Input.GetButtonDown("Jump"))
        {
            loader.SetActive(true);
            mainMovie.SetActive(false);

            SceneManager.LoadScene(0);
        }
        
    }
}
