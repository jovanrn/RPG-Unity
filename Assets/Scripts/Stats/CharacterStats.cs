using UnityEngine;

/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : MonoBehaviour {

	// Health
	public HealthBar healthBar;
	public int maxHealth = 100;
	public int currentHealth { get; private set; }
	public Stat damage;
	public Stat armor;

	public Transform FirePostition;
	public GameObject HealthEffect;
	bool inRangeOfFire = false;
	bool IsPlayer;
	public float distance = 4f;

	public GameObject heltGameObject;
	float lastMadeVisibleTime;
	float visibleTime = 5;

	public event System.Action<int, int> OnHealthChanged;

	


	bool flag = true;
	float elapsed = 0f;

	public GameObject HealingSound;

	private void Update()
	{
		if (IsPlayer && (FirePostition.position - transform.position).sqrMagnitude < distance * distance)
		{
			// Debug.Log("HEALING");
			

			elapsed += Time.deltaTime;
			if (elapsed >= .5f)
			{
				elapsed = elapsed % .5f;

				if (currentHealth > 0 && currentHealth < 100)
				{
					currentHealth += 2;
					healthBar.SetHealth(currentHealth);
					heltGameObject.SetActive(true);
					lastMadeVisibleTime = Time.time;
				    HealingSound.SetActive(true);

					if (flag)
					{
						HealthEffect.SetActive(true);
						flag = false;
						HealingSound.SetActive(true);

					}

				}
				else
				{
					
					if (flag==false)
					{
						HealthEffect.SetActive(false);
						flag = true;
						HealingSound.SetActive(false);
					}
				}
			}
		}
		else 
		{
			if (flag == false)
			{
				HealthEffect.SetActive(false);
				flag = true;
				HealingSound.SetActive(false);
			}

		}
	
	}


	void Awake ()
	{
		IsPlayer = GetComponent<PlayerStats>();
		heltGameObject.SetActive(true);
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		heltGameObject.SetActive(false);
	}


	void HealPlayer()
	{
		//     if ((transform.position - t.position).sqrMagnitude < distance * distance)

	}


	// Damage the character
	public void TakeDamage (int damage)
	{

		
		// Subtract the armor value
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		// Damage the character
		currentHealth -= damage;
		if (currentHealth <= 17 && currentHealth > 0)
		{
			FindObjectOfType<AudioManager>().Play("FinishHim");
		}


		heltGameObject.SetActive(true);
		lastMadeVisibleTime = Time.time;
		healthBar.SetHealth(currentHealth);
		Debug.Log(transform.name + " takes " + damage + " damage.");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

		// If health reaches zero
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public virtual void Die ()
	{
		// Die in some way
		// This method is meant to be overwritten
		Debug.Log(transform.name + " died.");
	}

	
	
	private void LateUpdate()
	{
		if (heltGameObject != null)
		{
			if (Time.time - lastMadeVisibleTime > visibleTime )
			{
				heltGameObject.SetActive(false);
			}
		}
	}
	
}
