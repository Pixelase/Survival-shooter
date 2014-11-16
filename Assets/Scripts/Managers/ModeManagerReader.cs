using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class ModeManagerReader : MonoBehaviour
{
	EnemyManager []enemies;

	void Start()
	{
		Initialization();
		ReadMode();
	}
	
	void ReadMode() 
	{
		try
		{
			enemies = GetComponents<EnemyManager>();
			using (StreamReader sr = new StreamReader("Mode.ini"))
			{
				foreach(EnemyManager enemy in enemies)
				{
					enemy.spawnTime = int.Parse(sr.ReadLine());
					enemy.deltaSpawnTime = enemy.spawnTime;
				}
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("The file could not be read:");
			Console.WriteLine(e.Message);
		}
	}

	void Initialization()
	{
		using (StreamWriter file = new StreamWriter("Mode.ini"))
		{
			file.WriteLine("3\n3\n10");
		}
	}
}
