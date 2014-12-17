using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;

public class ScoreResult : MonoBehaviour
{
	Text menuScoreText;
	string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Survival-shooter";

	void Awake()
	{
		menuScoreText = GetComponent <Text> ();
		ReadScoreResult();
	}
	
	void ReadScoreResult ()
	{
		try
		{
			if(File.Exists(path + @"\Score.log"))
			{
				menuScoreText.text = File.ReadAllText(path + @"\Score.log");
			}
		}

		catch (Exception e)
		{
			if(!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			
			using (StreamWriter sw = new StreamWriter (path + @"\Error.log", true))
			{
				sw.WriteLine(String.Format("{0:d.M.yyyy HH:mm}", DateTime.Now) +  " - Something wrong happened: " + e.Message.ToString().ToLower());
			}
		}
	}
}
