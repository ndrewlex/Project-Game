using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyType1;
	public GameObject enemyType2;
	GameObject Themaps;
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



		GameObject GoblinEnemy = (GameObject)Instantiate (enemyType1);
		GameObject ArcherEnemy = (GameObject)Instantiate (enemyType2);
		GoblinEnemy.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);
		ArcherEnemy.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);

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
			