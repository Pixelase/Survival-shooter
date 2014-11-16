using UnityEngine;
using System.Collections;

public class OptionResolution : MonoBehaviour
{
	bool isFullScreen = true;
	public void Back ()
	{
		Application.LoadLevel ("Option");
	}

	public void SetResolution1920 ()
	{
		Screen.SetResolution (1920, 1080, isFullScreen);
	}

	public void SetResolution1600 ()
	{
		Screen.SetResolution (1600, 900, isFullScreen);
	}

	public void SetResolution1280 ()
	{
		Screen.SetResolution (1280, 1024, isFullScreen);
	}

	public void SetResolution800 ()
	{
		Screen.SetResolution (800, 600, isFullScreen);
	}

	public void FullScreen()
	{
		if (isFullScreen == true)
			isFullScreen = false;
		else
			isFullScreen = true; 
	}
}
