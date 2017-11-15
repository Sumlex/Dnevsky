using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DieMenu : MonoBehaviour
{
    public GameObject Diemen;
    public Character character;
    private Saver saver;
    public GameObject LivesBar;

    string readPath;

    void Start()
    {
        readPath = Path.Combine(Application.dataPath, "Character.txt");
    }
    void Save()
    {
        string jsonString = JsonUtility.ToJson(character);
        File.WriteAllText(readPath, jsonString);
    }

    public void Update()
    {
        if (character.Hearts <= 0)
        {
            LivesBar.SetActive(false);
            Diemen.SetActive(true);
            Time.timeScale = 0;
            character.Hearts = 2;
            character.Lives = 4;
            character.score = 0;

            Save();
            
        }

    }

    public void Yes()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(character.Level);
        Diemen.SetActive(false);
    }
    public void No()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        Diemen.SetActive(false);
    }
}
