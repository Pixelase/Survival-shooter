using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour
{
	public void Normal ()
	{
		Application.LoadLevel ("MainMenu");
	}

	public void Insanity ()
	{
		Application.LoadLevel ("MainMenu");
	}
}
