using UnityEngine;
using System.Collections;

public class OptionQuality : MonoBehaviour
{
	public void Back ()
	{
		Application.LoadLevel ("Option");
	}

	public void Fantastic ()
	{
		QualitySettings.SetQualityLevel (10, true);
	}

	public void Normal ()
	{
		QualitySettings.SetQualityLevel (5, true);
	}

	public void Low ()
	{
		QualitySettings.SetQualityLevel (0, true);
	}
}
