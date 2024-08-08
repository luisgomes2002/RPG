using UnityEngine;

public class HealthComponent : MonoBehaviour
{
	[SerializeField] private float maxHealth;
	[SerializeField] private float currentHealth;
	[SerializeField] private bool isAlive;

	void Start()
	{
		currentHealth = maxHealth;
		isAlive = true;
	}

	void Update()
	{
		Die();
	}

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
	}

	void Die()
	{
		if (currentHealth <= 0)
		{
			isAlive = false;
			Destroy(this.gameObject);
		}
	}
}