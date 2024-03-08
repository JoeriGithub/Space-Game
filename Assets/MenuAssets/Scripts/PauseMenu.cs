using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject ExitGameUI;
	// Update is called once per frame

	private void Start()
	{
        Resume();
	}
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
		IsPaused = false;
	}

	void Pause()
    {
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
		IsPaused = true;
	}

    public void ExitGame()
    {
		PauseMenuUI.SetActive(false);
        ExitGameUI.SetActive(true);
	}
    public void NoButton()
    {
        ExitGameUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }
    public void YesButton()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

    public void Settings()
    {


    }

	
}
