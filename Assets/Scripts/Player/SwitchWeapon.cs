using UnityEngine;
using System.Collections;

public class SwitchWeapon : MonoBehaviour {

	public GameObject gun1;
	public GameObject gun2;
	public GameObject flashlight;	

	// Use this for initialization
	void Start ()
	{
		gun1.SetActive(true);
		gun2.SetActive(false);
	}

	// Update is called once per frame
	void Update ()
	{
		Switch();
	}

	void Switch()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			Start();
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{	
			gun1.SetActive(false);
			gun2.SetActive(true);
		}
		if(Input.GetKeyDown(KeyCode.F))
		{	
			if(flashlight.active) flashlight.SetActive(false);
			else flashlight.SetActive(true);
		}
	}

}
