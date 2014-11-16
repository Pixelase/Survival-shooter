using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour
{
	EnemyManager enemyManager;
	GameObject newObject;

	void Awake()
	{
		enemyManager = GetComponent <EnemyManager> ();
	}

	public void Normal()
	{

	}

	public void Insanity ()
	{
		
	}

	void Start ()
	{
		newObject = GameObject.Find ("EnemyManager");
	}
}
