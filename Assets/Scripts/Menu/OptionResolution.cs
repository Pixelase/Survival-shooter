using UnityEngine;
using System.Collections;

public class OptionResolution : MonoBehaviour
{
	public void Back ()
	{
		Application.LoadLevel ("Option");
	}

	public void SetResolution1920 ()
	{
		Screen.SetResolution (1920, 1080, true);
	}

	public void SetResolution1600 ()
	{
		Screen.SetResolution (1600, 900, true);
	}

	public void SetResolution1280 ()
	{
		Screen.SetResolution (1280, 1024, true);
	}

	public void SetResolution800 ()
	{
		Screen.SetResolution (800, 600, true);
	}
}
