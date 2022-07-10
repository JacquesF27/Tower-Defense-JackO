using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int value = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;
    private void Start()
    {
        speed = startSpeed;
        health = startHealth; 
    }


	public void TakeDamage(float amount)
	{
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
		{
            Die();
		}
	}

    public void Slow(float slowAmount)
	{
        speed = startSpeed * slowAmount;
	}

    void Die()
	{
        isDead = true;

        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
	}

    
}
