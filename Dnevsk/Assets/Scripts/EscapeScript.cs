using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EscapeScript : MonoBehaviour
{
    public GameObject EscapeMenu;
    public Character character;
    private Saver saver;

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

    private void Update()
    {
        
       if (EscapeMenu.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            EscapeMenu.SetActive(true);
        }
        else if (EscapeMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            EscapeMenu.SetActive(false);
        }

    }

    public void OnClickYes()
    {
        Time.timeScale = 1;
        character.Hearts = 2;
        character.Lives = 4;
        character.score = 0;

        Save();

        SceneManager.LoadScene(0);

    }
    public void No()
    {
        Time.timeScale = 1;
        EscapeMenu.SetActive(false);
    }
    
}
