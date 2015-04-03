using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuPauseManager : MonoBehaviour
{
	Text pauseText;
	bool IsSlowMotion;
	GameObject player;
	SwitchWeapon switchWeapon;
	PlayerHealth playerHealth;
	
	void Awake()
	{
		pauseText = GetComponent <Text>();
		player = GameObject.FindGameObjectWithTag ("Player");
		switchWeapon = player.GetComponent<SwitchWeapon>();
		playerHealth = player.GetComponent<PlayerHealth>();
	}
	
	void Update ()
	{
		GoToMainMenu ();
		Pause ();
		SlowMotion (); 
	}
	
	void Pause ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if(!playerHealth.isDead)
			{
				if (Time.timeScale >= 0.5f)
				{
					Time.timeScale = 0f;
					GetComponent<AudioSource>().Pause();
					pauseText.enabled = true;
					switchWeapon.enabled = false;
				}
				else if(IsSlowMotion)
				{
					Time.timeScale = 0.5f;
					GetComponent<AudioSource>().Play();
					pauseText.enabled = false;
					switchWeapon.enabled = true;
				}
				else
				{
					Time.timeScale = 1f;
					GetComponent<AudioSource>().Play();
					pauseText.enabled = false;
					switchWeapon.enabled = true;
				}
			}
		}
	}
	
	void SlowMotion ()
	{
		if (Input.GetKeyDown (KeyCode.R))
		{
			if (Time.timeScale == 1f)
			{
				Time.timeScale = 0.5f;
				IsSlowMotion = true;
			}
			else if(!pauseText.enabled)
			{
				Time.timeScale = 1f;
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
}
