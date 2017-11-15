using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public GameObject LevelChanger;
    public GameObject ExitPanel;
    public GameObject About;
    public GameObject canvas;
    public GameObject sound;
    public GameObject aboutM;

    private void Update()
    {
        if (LevelChanger.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            LevelChanger.SetActive(false);
        }
        else if (ExitPanel.activeSelf == false && Input.GetKeyDown(KeyCode.Escape) && canvas.activeSelf == true)
        {
            ExitPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPanel.SetActive(false);
        }
        if (About.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            About.SetActive(false);
            canvas.SetActive(true);
            sound.SetActive(true);
            aboutM.SetActive(false);
        }
       
    }
    public void OnClickAbout()
        {
            About.SetActive(true);
            canvas.SetActive(false);
            sound.SetActive(false);
            aboutM.SetActive(true);
        }
	public void OnClickStart()
        {
            LevelChanger.SetActive(true);
        }
    public void No()
        {
            ExitPanel.SetActive(false);
        }
    public void Exit()
        {
        Application.Quit();
        }
    public void OnclickExit()
    {
        ExitPanel.SetActive(true);
    }

    public void LevelButtons(int level)
        {
        SceneManager.LoadScene(level);
        }
}