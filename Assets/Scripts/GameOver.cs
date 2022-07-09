using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public Text wavesText;

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	private void OnEnable()
	{
		wavesText.text = PlayerStats.waves.ToString();
	}

	public void Retry()
	{
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void Menu()
	{
		sceneFader.FadeTo(menuSceneName);
	}
}
