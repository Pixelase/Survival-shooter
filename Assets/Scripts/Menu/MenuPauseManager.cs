using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuPauseManager : MonoBehaviour
{
	public Text text;

	void Start()
	{
		text = GetComponent <Text> ();
	}

	void Update ()
	{
		GoToMainMenu ();
		Pause ();
		SlowMotion (); 
		Exit ();
	}

	void Pause ()
	{
		if (Input.GetKeyDown (KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				audio.Pause();
				//text.color.a = 255;
			}
			else
			{
				Time.timeScale = 1;
				audio.SetScheduledStartTime(0f);
				audio.Play();
				//text.color.a = 0;
			}
		}
	}

	void SlowMotion ()
	{
		if (Input.GetKeyDown (KeyCode.O))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0.5f;
				audio.Pause();
			}
			else
			{
				Time.timeScale = 1;
				audio.SetScheduledStartTime(0f);
				audio.Play();
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
