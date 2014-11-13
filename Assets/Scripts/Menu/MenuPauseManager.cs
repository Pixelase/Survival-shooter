using UnityEngine;
using System.Collections;

public class MenuPauseManager : MonoBehaviour
{
	void Update ()
	{
		GoToMainMenu ();
		Pause ();
		Exit ();
	}

	static void Pause ()
	{
		if (Input.GetKeyDown (KeyCode.P))
		{
			if (Time.timeScale ==1)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}
	}

	static void GoToMainMenu()
	{
		if (Input.GetKeyDown (KeyCode.M))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	static void Exit()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
