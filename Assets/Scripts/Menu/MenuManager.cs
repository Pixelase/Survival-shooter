using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour 
{
	public Texture2D crosshair;

	void Awake()
	{
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}

	public void NewGame()
	{
		Application.LoadLevel ("MainScene");
		Time.timeScale = 1f;
		Cursor.SetCursor (crosshair, Vector2.zero, CursorMode.Auto);
	}

	public void Exit()
	{
	   Application.Quit ();
	}

	public void Help()
	{
		Application.LoadLevel ("Help");
	}

	public void BackToMainMenu()
	{
		Application.LoadLevel ("MainMenu");
	}

	public void About()
	{
		Application.LoadLevel ("About");
	}

	public void Option()
	{
		Application.LoadLevel ("Option");
	}

	public void Score()
	{
		Application.LoadLevel ("Score");
	}

	public void OptionResolution()
	{
		Application.LoadLevel ("OptionResolution");
	}

	public void OptionQuality()
	{
		Application.LoadLevel ("OptionQuality");
	}

	public void OptionMode ()
	{
		Application.LoadLevel ("OptionMode");
	}
}