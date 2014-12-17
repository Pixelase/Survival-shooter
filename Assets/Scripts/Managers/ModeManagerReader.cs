using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class ModeManagerReader : MonoBehaviour
{
	EnemyManager []enemies;
	string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Survival-shooter";

	void Awake()
	{
		ReadMode();
	}
	
	void ReadMode() 
	{
		try
		{
			enemies = GetComponents<EnemyManager>();
			if(File.Exists(path + @"\Mode.ini"))
			{
				using (StreamReader sr = new StreamReader(path + @"\Mode.ini"))
				{
					foreach(EnemyManager enemy in enemies)
					{
						enemy.spawnTime = float.Parse(sr.ReadLine());
						enemy.deltaSpawnTime = enemy.spawnTime;
					}
				}
			}
			else
			{
				if(!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				File.WriteAllText(path + @"\Mode.ini", "3\n3\n10\n");
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
