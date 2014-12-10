using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;

public class ScoreResult : MonoBehaviour
{
	Text menuScoreText;

	void Awake()
	{
		menuScoreText = GetComponent <Text> ();
		ReadScoreResult();
	}
	
	void ReadScoreResult ()
	{
		try
		{
			menuScoreText.text = File.ReadAllText("Score.log");
		}
		catch (Exception e)
		{
			File.WriteAllText("Error.log", String.Format("{0:d.M.yyyy HH:mm}", DateTime.Now) +  " - the file could not be read:\n" + e.Message.ToString() + "\n");
		}
	}
}
