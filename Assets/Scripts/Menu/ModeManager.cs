using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour
{
	public void Normal()
	{
		using (System.IO.StreamWriter file = new System.IO.StreamWriter("Mode.ini"))
		{
			file.WriteLine("3\n3\n10");
		}
		Application.LoadLevel("Option");
	}

	public void Insanity ()
	{
		using (System.IO.StreamWriter file = new System.IO.StreamWriter("Mode.ini"))
		{
			file.WriteLine("2\n2\n6");
		}
		Application.LoadLevel("Option");
	}

}
