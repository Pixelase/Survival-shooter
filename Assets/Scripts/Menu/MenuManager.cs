﻿using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour 
{
	public void NewGame()
	{
		Application.LoadLevel ("MainScene");
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

}
