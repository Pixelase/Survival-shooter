using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuPauseManager : MonoBehaviour
{
	Text pauseText;
	bool IsSlowMotion;
	GameObject player;
	SwitchWeapon switchWeapon;
	
	void Awake()
	{
		pauseText = GetComponent <Text>();
		player = GameObject.FindGameObjectWithTag ("Player");
		switchWeapon = player.GetComponent<SwitchWeapon>();
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
			if (Time.timeScale >= 0.5)
			{
				Time.timeScale = 0;
				audio.Pause();
				pauseText.enabled = true;
				switchWeapon.enabled = false;
			}
			else if(IsSlowMotion)
			{
				Time.timeScale = 0.5f;
				audio.Play();
				pauseText.enabled = false;
				switchWeapon.enabled = true;
			}
			else
			{
				Time.timeScale = 1;
				audio.Play();
				pauseText.enabled = false;
				switchWeapon.enabled = true;
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
				IsSlowMotion = true;
			}
			else if(!pauseText.enabled)
			{
				Time.timeScale = 1;
				IsSlowMotion = false;
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
