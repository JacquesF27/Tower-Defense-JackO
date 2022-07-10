using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public static int enemiesAlive = 0;
	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5.5f;
	private float countdown = 2f;

	public Text waveCountdownText;
	public Text waveCountDisplay;

	public GameManager gameManager;

	

	private int waveIndex = 0;
	private void Update()
	{
		if (enemiesAlive > 0)
		{
			return;
		}
		
		if (waveIndex == waves.Length)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}

		if (countdown <= 0)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountDisplay.text = "Current Wave: " + (waveIndex + 1) + "/" + waves.Length;
		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave()
	{
		PlayerStats.waves++;

		Wave wave = waves[waveIndex];

		enemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{	
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}
		waveIndex++;
	}

	void SpawnEnemy(GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}
}
