using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLevelLoader : MonoBehaviour {

    public GameObject First;
    public GameObject Second;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (First.activeSelf == true && Input.GetButton("Jump"))
        {
            First.SetActive(false);
            Second.SetActive(true);
        }

    }
}
