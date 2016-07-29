using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

	private int maxSkill = 1;
	private bool skill;
	private int skillIndex;
	private float time = 5;
	private float timeCounter;
	public GameObject enemyA;
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		timeCounter = time;
		//skillIndex = Random.Range (0, maxSkill);
	}
	
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if ( other.gameObject.name == "Player")
		{	
			Destroy (gameObject);
		}
			
			
			/*else if ( Random.Range (0, maxSkill)== 1)
			{
				enemyA.GetComponent<EnemyAController>().setMoving(0f);
				Destroy(gameObject);
			}*/
		
	}
}

