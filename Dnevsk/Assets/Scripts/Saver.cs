using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Saver : MonoBehaviour
{
    public Character character;


    string readPath;
    private string FilePath1;

    private LivesBar livesBar;
    MenuScript menuscript;
    EscapeScript escape;

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        escape = FindObjectOfType<EscapeScript>();
    }

    void Start()
    {
        readPath = Path.Combine(Application.dataPath, "Character.txt");
            Load();
        
    }
    public void FixedUpdate()
    {
        Save();
    }

    void Save()
    {
            string jsonString = JsonUtility.ToJson(character);
            File.WriteAllText(readPath, jsonString);
    }

    void Load()
    {
            string jsonString = File.ReadAllText(readPath);
            JsonUtility.FromJsonOverwrite(jsonString, character);
    }
}
