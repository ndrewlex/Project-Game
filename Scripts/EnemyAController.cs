using UnityEngine;
using System.Collections;

public class EnemyAController : MonoBehaviour {

	public Transform target;
	public float range=1f;
	public float moveSpeed;
	private Vector2 direction;
	private Animator anim;
	private Rigidbody2D myRigidbody;
	private float distance;

	public Vector2 enemyAPos;
	public Vector2 playerPos;
	private Vector2 velocity;

	private bool moving;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;

	public float timeToMove;
	private float timeToMoveCounter;

	private Vector2 moveDirection;
	private Vector2 moveDirectionY;

	public float x, y;
	// Use this for initialization
	void Start ()

	{
		target = GameObject.Find ("Player").transform;
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D> ();
		timeBetweenMoveCounter = timeBetweenMove;
		timeToMoveCounter = timeToMove;
	}

	void Update()
	{
	// Update is called once per frame
	Vector2 direction = target.transform.position - transform.position;
	direction.Normalize ();
	//float distance = Vector2.Distance (target.transform.position, transform.position);
		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;
			if (timeToMoveCounter < 0f)
			{
				moving = false;
				timeToMoveCounter = timeToMove;
				anim.SetBool ("MovingA", false);
			} 
		}

		else{
		if (timeBetweenMoveCounter < 0) 
		{
			moving = true;
			moveDirection = new Vector2 ( direction.x * moveSpeed, direction.y*moveSpeed);
			timeBetweenMoveCounter = timeBetweenMove;
			anim.SetBool ("MovingA", true);
			anim.SetFloat ("EnemyAX", direction.x);
			anim.SetFloat ("EnemyAY", direction.y);
		} 
		else 
		{
		moving = false;
		timeBetweenMoveCounter -= Time.deltaTime;
		myRigidbody.velocity = Vector2.zero;
		anim.SetBool ("MovingA", false);
		}
		}
	}
}

