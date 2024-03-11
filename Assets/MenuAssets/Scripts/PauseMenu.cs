using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject ExitGameUI;
    public GameObject SettingsUI;
	// Update is called once per frame

	private void Start()
	{
		Time.timeScale = 1f;
		PauseMenuUI.SetActive(false);
		SettingsUI.SetActive(false);
		ExitGameUI.SetActive(false);
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
		Time.timeScale = 1f;
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
	}

    public void Settings()
    {
        PauseMenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void ReturnButton()
    {
        SettingsUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

	
}
