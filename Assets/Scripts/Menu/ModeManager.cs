using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class ModeManager : MonoBehaviour
{
	public float normalZomBunnySpawnTime;
	public float normalZomBearSpawnTime;
	public float normalHellephantSpawnTime;

	public float insanityZomBunnySpawnTime;
	public float insanityZomBearSpawnTime;
	public float insanityHellephantSpawnTime;

	string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Survival-shooter";

	void Start()
	{
		normalZomBunnySpawnTime = 3f;
		normalZomBearSpawnTime = 3f;
		normalHellephantSpawnTime = 10f;

		insanityZomBunnySpawnTime = 1.5f;
     	insanityZomBearSpawnTime = 1f;
     	insanityHellephantSpawnTime = 3f;
	}

	public void Normal()
	{
		WriteMode(normalZomBunnySpawnTime, normalZomBearSpawnTime, normalHellephantSpawnTime);
		Application.LoadLevel("Option");
	}

	public void Insanity ()
	{
		WriteMode(insanityZomBunnySpawnTime, insanityZomBearSpawnTime, insanityHellephantSpawnTime);
		Application.LoadLevel("Option");
	}

	void WriteMode(float zombunnyST, float zomBearST, float hellephantST)
	{
		try
		{
			if(!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			
			using (StreamWriter sw = new StreamWriter(path + @"\Mode.ini"))
			{
				sw.WriteLine("{0}\n{1}\n{2}", zombunnyST, zomBearST, hellephantST);
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
