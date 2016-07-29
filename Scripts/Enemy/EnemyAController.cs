using UnityEngine;
using System.Collections;


public class EnemyAController : MonoBehaviour {
	
	public Transform target;
	private Vector2 direction;
	public float speed=0.5f;
	public float range=1f;
	public bool moving;
	private Rigidbody2D myRigidBody;
	private Animator anim;
	private float RandomX;
	private float RandomY;
	private GameObject FixMaps;

	void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D> ();
		target = GameObject.Find ("Player").transform;
		//coord = Instantiate ("tileground");
		moving = true;
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		if (moving) {
			
			float distance = Vector2.Distance (target.transform.position, transform.position);

			if (distance < 1.5f) {
				anim.SetBool ("Attacking", true);
			} else if (distance <= 5f) {
				direction = target.transform.position - transform.position;
				direction.Normalize ();
				Vector2 velocity = direction * speed;
				anim.SetBool ("MovingA", true);
				anim.SetFloat ("EnemyAX", velocity.x);
				anim.SetFloat ("EnemyAY", velocity.y);
				myRigidBody.velocity = new Vector2 (velocity.x, velocity.y);


			} else if (distance > 5f) {
				Invoke ("RandomlyMove", 1.5f);
				Vector2 direction = new Vector2 (RandomX, RandomY);
				myRigidBody.velocity = new Vector2 (direction.x, direction.y);
				anim.SetBool ("MovingA", true);
				anim.SetFloat ("EnemyAX", direction.x);
				anim.SetFloat ("EnemyAY", direction.y);

			}
		} else {
			this.speed = 0;
		}
			

	}

	void RandomlyMove() {
		RandomX = Random.Range (-1, 1) * speed;
		RandomY = Random.Range (-1, 1) * speed;

		if (transform.position.x < -16f) {
			RandomX = 2;
			RandomY = Random.Range (-1, 1) * speed;
		} else if (transform.position.x > 17f) {
			RandomX = -2;
			RandomY = Random.Range (-1, 1) * speed;
		} else if (transform.position.y > 17f) {
			RandomX = Random.Range (-1, 1) * speed;
			RandomY = -2;
		}
		else if (transform.position.y < -16f) {
			RandomX = Random.Range (-1, 1) * speed;
			RandomY = 2;
		}

		CancelInvoke("RandomlyMove");
	}

	public void setMoving(float speed)
	{
		this.speed = speed;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Collision") 
		{
			myRigidBody.velocity =  Vector2.zero;
			anim.SetBool ("MovingA", false);
		}
	}

}



