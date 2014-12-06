﻿using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour
{
	public float normalZomBunnySpawnTime;
	public float normalZomBearSpawnTime;
	public float normalHellephantSpawnTime;

	public float insanityZomBunnySpawnTime;
	public float insanityZomBearSpawnTime;
	public float insanityHellephantSpawnTime;

	void Start()
	{
		normalZomBunnySpawnTime = 3f;
		normalZomBearSpawnTime = 3f;
		normalHellephantSpawnTime = 10f;

		insanityZomBunnySpawnTime = 1.5f;
     	insanityZomBearSpawnTime = 1.5f;
     	insanityHellephantSpawnTime = 4f;
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
		using (System.IO.StreamWriter file = new System.IO.StreamWriter("Mode.ini"))
		{
			file.Write("{0}\n{1}\n{2}", zombunnyST, zomBearST, hellephantST);
		}
	}
}
