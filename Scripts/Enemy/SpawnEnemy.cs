using UnityEngine;
using System.Collections;

public class SpawnEnemy: MonoBehaviour {

	public GameObject enemyA;
	public GameObject enemyB;
	private int x=0;
	private int maxEnemyCount = 5;
	const float range = 10.0f;
	public float SpawnStartDelay;
	public float repeatRate;
	public Transform[] SpawnPoints;

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("Spawn", SpawnStartDelay ,repeatRate);

	}
	
	void Spawn()
	{	
		
		Instantiate (enemyB, SpawnPoints [0].position, SpawnPoints [0].rotation);
		Instantiate (enemyB, SpawnPoints [1].position, SpawnPoints [1].rotation);
		Instantiate (enemyA, SpawnPoints [2].position, SpawnPoints [2].rotation);
		Instantiate (enemyA, SpawnPoints [3].position, SpawnPoints [3].rotation);
		x++;
		if (x >=  maxEnemyCount)  {
			CancelInvoke ("Spawn");
		}

	}

}
