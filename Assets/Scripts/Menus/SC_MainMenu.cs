using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
	public GameObject MainMenu;
	public GameObject LoadGameMenu;
	public GameObject SettingsMenu;
	[SerializeField] private string _newGameScene;

	// Start is called before the first frame update
	void Start()
	{
		ReturnButton();
	}

	public void NewGameButton()
	{
		// New Game Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
		UnityEngine.SceneManagement.SceneManager.LoadScene(_newGameScene);
	}

	public void LoadGameButton()
	{
		// Open Load Game Menu
		MainMenu.SetActive(false);
		LoadGameMenu.SetActive(true);
	}
	public void SettingsButton()
	{
		//Open Settings Menu
		MainMenu.SetActive(false);
		SettingsMenu.SetActive(true);
	}

	public void ReturnButton()
	{
		// Show Main Menu
		MainMenu.SetActive(true);
		LoadGameMenu.SetActive(false);
		SettingsMenu.SetActive(false);
	}


	public void ExitButton()
	{
		// Exit Game
		Application.Quit();
	}



}