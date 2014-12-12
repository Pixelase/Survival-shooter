using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class ModeManagerReader : MonoBehaviour
{
	EnemyManager []enemies;

	void Awake()
	{
		ReadMode();
	}
	
	void ReadMode() 
	{
		try
		{
			enemies = GetComponents<EnemyManager>();
			if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter\Mode.ini"))
			{
				using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter\Mode.ini"))
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
				if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter"))
				{
					Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter");
				}
				File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter\Mode.ini", "3\n3\n10\n");
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
