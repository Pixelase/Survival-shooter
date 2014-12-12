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
			if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter\Score.log"))
			{
				menuScoreText.text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter\Score.log");
			}
		}
		catch (Exception e)
		{
			if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter"))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter");
			}

			File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter\Error.log", String.Format("{0:d.M.yyyy HH:mm}", DateTime.Now) +  " - Something wrong happened: " + e.Message.ToString() + "\n");
		}
	}
}
