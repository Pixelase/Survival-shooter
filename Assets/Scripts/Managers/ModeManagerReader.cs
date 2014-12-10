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
			if(File.Exists("Mode.ini"))
			{
				using (StreamReader sr = new StreamReader("Mode.ini"))
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
				File.WriteAllText("Mode.ini", "3\n3\n10\n");
			}		
		}
		catch (Exception e)
		{
			Console.WriteLine("The file could not be read:");
			Console.WriteLine(e.Message);
		}
	}
}
