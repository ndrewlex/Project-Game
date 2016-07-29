using UnityEngine;
using System.Collections;

public class SpawnItems : MonoBehaviour {

	public GameObject item;
	const float range = 10.0f;
	private float SpawnStartDelay = 5.0f;
	private float repeatRate = 5.0f;
	public Transform[] SpawnPoints;
	private double x = 0;
	private float waitTime = 5.0f;
	private float timeExist = 2f;
	private float waitTimeCounter;
	private double maxItem = 3;
	private double destroyTimeCounter = 10.0f;
	private int maxSkill = 1, skillIndex;
	private EnemyBController enemyB;
	private EnemyAController enemyA;



	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", SpawnStartDelay,waitTime);
		waitTimeCounter = waitTime;
	}


	void Spawn()
	{
		//int spawnIndex = Random.Range (0, SpawnPoints.Length);
		Instantiate (item, SpawnPoints [Random.Range (0, SpawnPoints.Length)].position, SpawnPoints [Random.Range (0, SpawnPoints.Length)].rotation);
		Instantiate (item, SpawnPoints [Random.Range (0, SpawnPoints.Length)].position, SpawnPoints [Random.Range (0, SpawnPoints.Length)].rotation);
		Instantiate (item, SpawnPoints [Random.Range (0, SpawnPoints.Length)].position, SpawnPoints [Random.Range (0, SpawnPoints.Length)].rotation);

	}

}
