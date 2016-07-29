
using UnityEngine;
using System.Collections;

public class AttackEnemyB : MonoBehaviour 
{
	private EnemyBController enemyB;
	public Transform target;
	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;
	public GameObject bullet4;
	private float s;
	private Animator anim;
	private EnemyBController enemy;
	private Rigidbody2D myRigidBody;
	private float counter;
	private Vector2 direction;
	private Vector2 moveDirection;
	private GameObject Obtained;
	public int BulletType=0;
	private Vector2 lastMove;
	private float duration;
	private float distance;
	public Transform LaunchPoint ;
	void Start () 
	{
		anim = this.GetComponent<Animator> ();
		enemyB= GetComponent<EnemyBController> ();
		target = GameObject.Find ("Player").transform;
		duration = 3.0f;
		counter = duration;
	}

	// Update is called once per frame

	void Update ()
	{ 
		distance = Vector2.Distance (target.transform.position, transform.position);
		if (distance < 10.0f) {
			if (anim.GetBool ("MovingB") == true) {
				counter -= Time.deltaTime;
				if (counter > 0) {
					counter = -Time.deltaTime;
					direction = target.transform.position - transform.position;
					direction.Normalize ();
					anim.SetBool ("MovingB", false);

				} else if (counter < 0) {
					enemyB.timeToMoveCounter = 0;
					s = Mathf.Sqrt ((direction.x * direction.x) + (direction.y * direction.y));
					if (direction.x != 0 && direction.y == 0) {
						//moveDirection = new Vector2 (0, direction.y);
						lastMove = new Vector2 (0, direction.y); 
						anim.SetBool ("AttackingB", true);
						Invoke ("attack", 1f);

					} else if (direction.y != 0 && direction.x == 0) {
						//moveDirection = new Vector2 (direction.x, 0);
						anim.SetFloat ("LastMoveBX", direction.x);
						anim.SetBool ("AttackingB", true);
						Invoke ("attack", 1f);

					} else if (direction.x != 0 && direction.y != 0) 
					{
						moveDirection = new Vector2 ((direction.x/s ) , (direction.y/s));
						anim.SetBool ("AttackingB", true);
						anim.SetFloat ("EnemyBX", moveDirection.x);
						anim.SetFloat ("EnemyBY", moveDirection.y);
						//anim.SetFloat ("LastMoveBX", direction.x);
						//anim.SetFloat ("LastMoveBY", direction.y);
						Invoke ("attack", 1f);
						//anim.SetBool ("AttackingB", false);
					}
					//else if(enemyB.timeBetweenMoveCounter
					counter = duration;
				} else if (enemy.timeToMoveCounter < 0) {
					anim.SetBool ("AttackingB", false);
					//CancelInvoke ("attack");
				} else {
					anim.SetBool ("AttackingB", false);
				}
			}
		}
	}

	void attack()
	{
			if(moveDirection.x > 0f && (moveDirection.y > -2 || moveDirection.y < 2))
			{
				Instantiate (bullet1, LaunchPoint.position, LaunchPoint.rotation);
			}
			else if(moveDirection.x < 0f && (moveDirection.y > -2 || moveDirection.y < 2))
			{
				Instantiate (bullet2, LaunchPoint.position, LaunchPoint.rotation);
			}
			else if((moveDirection.y > -2f && moveDirection.x > 2f) || (moveDirection.y < 2f && moveDirection.x > 2f))
			{
				Instantiate (bullet3, LaunchPoint.position, LaunchPoint.rotation);
			}
			else if((moveDirection.y > -2f && moveDirection.x < -2f) || (moveDirection.y < 2f && moveDirection.x < -2f))
			{
				Instantiate (bullet4, LaunchPoint.position, LaunchPoint.rotation);
			}
		
		/*
		if (direction.x <= 0  && direction.y  -2.0) {
			Instantiate (bullet4, LaunchPoint.position, LaunchPoint.rotation);
		} else if (direction.x >= 0 && (direction.y < -2.0)) {
			Instantiate (bullet4, LaunchPoint.position, LaunchPoint.rotation);

		} else if (direction.y >= 0 && (direction.x < 2.0)) {
			Instantiate (bullet3, LaunchPoint.position, LaunchPoint.rotation);
		} else if (direction.y >= 0 && (direction.x > -2.0)) {
			Instantiate (bullet3, LaunchPoint.position, LaunchPoint.rotation);
		} else if (direction.y >= -2.0 && (direction.x < 0)) {
			Instantiate (bullet2, LaunchPoint.position, LaunchPoint.rotation);
		}
		else if (direction.y >= 0 && (direction.x <= 0)) {
			Instantiate (bullet2, LaunchPoint.position, LaunchPoint.rotation);
		}
		else if (direction.y >= -2.0 && (direction.x >= 0)) {
			Instantiate (bullet1, LaunchPoint.position, LaunchPoint.rotation);
		}
		else if (direction.y >= 0 && (direction.x >= 0)) {
			Instantiate (bullet1, LaunchPoint.position, LaunchPoint.rotation);
		}
		
	}*/
	}
}