using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;

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
			if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter"))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter");
			}
			
			using (StreamWriter sw = new StreamWriter (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter\Score.log", true))
			{
				sw.WriteLine("Time: {0} <--> Score: {1}", String.Format("{0:d.M.yyyy HH:mm}", DateTime.Now), ScoreManager.score);
			}
		}

		catch (Exception e)
		{
			if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter"))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter");
			}
			
			File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Survival-shooter\Error.log", String.Format("{0:d.M.yyyy HH:mm}", DateTime.Now) +  " - Something wrong happened: " + e.Message.ToString() + "\n");
		}
	}
}
