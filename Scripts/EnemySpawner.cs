using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyType;
	float maxSpawnRateInSeconds = 30f;

	// Use this for initialization
	void Start () 
	{
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
		InvokeRepeating ("IncreaseSpawnRate", 0f, 10f);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void SpawnEnemy()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject anEnemy = (GameObject)Instantiate (enemyType);
		anEnemy.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);

		ScheduleNextEnemySpawn();
	}

	void ScheduleNextEnemySpawn()
	{
		float spawnInNSeconds;
		if (maxSpawnRateInSeconds > 1f) {
			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else
			spawnInNSeconds = 1f;
		Invoke ("SpawnEnemy", spawnInNSeconds);
	}

	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;
		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}
}
			