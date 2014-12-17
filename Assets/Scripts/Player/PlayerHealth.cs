using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

//For reverse sorting in Sorted List or Dictionary
class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
{
	public int Compare(T x, T y) {
		return y.CompareTo(x);
	}
}

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
	SwitchWeapon switchWeapon;
    public bool isDead;
    bool damaged;
	string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Survival-shooter";


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
		switchWeapon = GetComponent<SwitchWeapon>();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;
		switchWeapon.enabled = false;
		
		Time.timeScale = 1f;

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;

		foreach(PlayerShooting playerShooting in GetComponentsInChildren <PlayerShooting> ())
		{
			playerShooting.DisableEffects();
			playerShooting.enabled = false;
		}

		WriteScoreLog ();
    }

	void WriteScoreLog()
	{
		try
		{
			SortedList<int, string> scores = new SortedList<int, string>(new DescendingComparer<int>());

			if(!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			if(File.Exists(path + @"\Score.log"))
			{
				foreach(string s in File.ReadAllLines(path + @"\Score.log"))
				{
					try
					{
						int key = int.Parse(Regex.Match(s, @"\d+\s*$").ToString());
						string value = Regex.Match(s, @"\d+\.\d+\.\d+\s+\d+\:\d+").ToString();
						scores.Add(key, value);
					}

					catch (Exception e)
					{
						if(!Directory.Exists(path))
						{
							Directory.CreateDirectory(path);
						}
						
						using (StreamWriter sw = new StreamWriter (path + @"\Error.log", true))
						{
							sw.WriteLine(String.Format("{0:d.M.yyyy HH:mm}", DateTime.Now) +  " - Something wrong happened: " + e.Message.ToString().ToLower());
						}
					}
				}
			}

			if(scores.ContainsKey(ScoreManager.score))
			{
				int index = ScoreManager.score;
				scores[index] = String.Format("{0:d.M.yyyy HH:mm}", DateTime.Now);
			}
			else
			{
				scores.Add(ScoreManager.score, String.Format("{0:d.M.yyyy HH:mm}", DateTime.Now));
			}

			if(scores.Count > 12)
			{
				for(int i = 12; i < scores.Count; i++)
				scores.RemoveAt(i);
			}

			using (StreamWriter sw = new StreamWriter (path + @"\Score.log"))
			{
				foreach(KeyValuePair<int, string> score in scores)
				{
					sw.WriteLine("Time: {1} <--> Score: {0}", score.Key, score.Value);
				}
			}
		}

		catch (Exception e)
		{
			if(!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			using (StreamWriter sw = new StreamWriter (path + @"\Error.log", true))
			{
				sw.WriteLine(String.Format("{0:d.M.yyyy HH:mm}", DateTime.Now) +  " - Something wrong happened: " + e.Message.ToString().ToLower());
			}
		}
	}
}
