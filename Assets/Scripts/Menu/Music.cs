using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
    public static Music instance = null;

	void Start ()
	{
		if(instance!=null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;

		DontDestroyOnLoad (gameObject);

		audio.Play ();
	}

	void Update()
	{

		if (Application.loadedLevelName == "MainScene" || Application.loadedLevelName == "About")
		{
			StopPlay();
		}
	}

	void StopPlay()
	{
		Destroy (gameObject);
		audio.Pause ();
	}
}