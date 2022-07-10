using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{

    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void Menu()
	{
        sceneFader.FadeTo(menuSceneName);
	}

    public void Continue()
	{
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
   
}
