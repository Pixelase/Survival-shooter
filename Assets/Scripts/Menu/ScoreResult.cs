using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;

public class ScoreResult : MonoBehaviour
{
	Text text;

	void Start()
	{
		text = GetComponent <Text> ();
		ReadingScoreResult ();
	}
	
	void ReadingScoreResult ()
	{
		try
		{
			text.text = System.IO.File.ReadAllText("Score.log");
		}
		catch (Exception e)
		{
			Console.WriteLine("The file could not be read:");
			Console.WriteLine(e.Message);
		}
	}
}
