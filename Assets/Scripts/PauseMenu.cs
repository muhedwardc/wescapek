using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    public Button button;
    public bool resetSpeed = false;

    public bool paused = false;
    public bool pauseBtnClicked = false;
    public bool gameOver = false;

	// Use this for initialization
	void Start () {
        Button pauseBtn = button.GetComponent<Button>();
        pauseBtn.onClick.AddListener(pauseOnClick);
        PauseUI.active = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (pauseBtnClicked)
        {
            paused = !paused;
            pauseOnClick();
        }

        if (paused)
        {
            PauseUI.active = true;
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.active = false;
            Time.timeScale = 1;
        }
	}

    public void pauseOnClick()
    {
        pauseBtnClicked = !pauseBtnClicked;
    }

    // resume
    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        resetSpeed = true;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
