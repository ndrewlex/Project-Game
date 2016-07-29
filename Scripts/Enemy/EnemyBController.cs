/*using UnityEngine;
using System.Collections;

public class EnemyBController : MonoBehaviour {

	public Transform target;
	public Transform LaunchPoint;
	public float range=10f;
	public float moveSpeed;
	private Vector2 direction;
	private Animator anim;
	private Rigidbody2D myRigidbody;
	private float distance;

	private Vector2 lastMoveB;
	private Vector2 velocity;
	private int x=0;
	private bool moving;
	private bool attack;

	public float waitBetweenShot;
	private float shotCounter;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;

	public float timeToMove;
	private float timeToMoveCounter;

	private Vector2 moveDirection;

	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;
	private Vector2 moveDirectionY;
	public GameObject Bullet;
	// Use this for initialization
	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		target = GameObject.Find ("Player").transform;
		anim = GetComponent<Animator>();
		shotCounter = waitBetweenShot;
		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}

	void Update()
	{
		// Update is called once per frame
		float distance = Vector2.Distance (target.transform.position, transform.position);
	
		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;
				
			if (timeToMoveCounter < 0f) {
				moving = false;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
				anim.SetBool ("MovingB", false);

			} 
		} else if (!moving) {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter < 0) {
				moving = true;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);
				moveDirection = new Vector2 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed);
				if (moveDirection.x > moveDirection.y) {
					lastMoveB = new Vector2 (0f, moveDirection.y); 
				} else if (moveDirection.x < moveDirection.y) {
					lastMoveB = new Vector2 (moveDirection.x, 0f); 
				}
				anim.SetFloat ("LastMoveBX", lastMoveB.x);
				anim.SetFloat ("LastMoveBY", lastMoveB.y);
				anim.SetBool ("MovingB", true);
				anim.SetFloat ("EnemyBX", moveDirection.x);
				anim.SetFloat ("EnemyBY", moveDirection.y);
			}
		}

		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				Application.LoadLevel (Application.loadedLevel);
				thePlayer.SetActive (true);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player") {
			other.gameObject.SetActive(false);
			reloading = true;
			thePlayer = other.gameObject;
		}
		if (other.gameObject.name == "CollisionAvoid") {
			moving = false;
			anim.SetBool ("MovingA", false);
		}

	}

}

*/

using UnityEngine;
using System.Collections;

public class EnemyBController : MonoBehaviour {

	public Transform target;
	public float range=10f;
	public float moveSpeed;
	private Vector2 direction;
	private Animator anim;
	private Rigidbody2D myRigidbody;
	private float distance;
	private Vector2 lastMoveB;
	private Vector2 velocity;
	private int x = 0;

	private bool moving;
	private bool attack;

	public float timeBetweenMove = 4f;
	public float timeBetweenMoveCounter;

	public float timeToMove = 3f;
	public float timeToMoveCounter;

	private Vector2 moveDirection;
	private Vector2 moveDirectionY;
	private ScoreManager theScore;
	
	// Use this for initialization
	void Start ()

	{
		myRigidbody = GetComponent<Rigidbody2D>();
		target = GameObject.Find ("Player").transform;
		anim = GetComponent<Animator>();
		timeBetweenMoveCounter = timeBetweenMove;
		timeToMoveCounter = timeToMove;
		theScore = FindObjectOfType<ScoreManager> ();
	}

	void Update()
	{
		// Update is called once per frame
		Vector2 direction = target.transform.position - transform.position;
		direction.Normalize ();
		float distance = Vector2.Distance (target.transform.position, transform.position);
		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0f) 
			{
				moving = false;
				//timeToMoveCounter = timeToMove;
				timeBetweenMoveCounter = timeBetweenMove;
				anim.SetBool ("MovingB", false);
			} 

		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if (timeBetweenMoveCounter < 0) {
				moving = true;
				timeToMoveCounter = timeToMove;
				moveDirection = new Vector2 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed);
				if (moveDirection.x > moveDirection.y) {
					lastMoveB = new Vector2 (0f, moveDirection.y); 
				} else if (moveDirection.x < moveDirection.y) {
					lastMoveB = new Vector2 (moveDirection.x, 0f); 
				}
				anim.SetFloat ("LastMoveBX", lastMoveB.x);
				anim.SetFloat ("LastMoveBY", lastMoveB.y);
				anim.SetBool ("MovingB", true);
				anim.SetFloat ("EnemyBX", moveDirection.x);
				anim.SetFloat ("EnemyBY", moveDirection.y);
			}
		}

	}

	/*public bool setMoving(bool moving)
	{
		this.moving = moving;
	}*/

		
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Collision") {
			this.moving = false;
			this.myRigidbody.velocity = Vector2.zero;
			this.anim.SetBool ("MovingA", false);
		}

	}
}