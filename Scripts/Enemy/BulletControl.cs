using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {
	public float speed;
	private Animator anim;
	private Transform Player ;
	//public GameObject enemyDeathEffect;
	private GameObject thePlayer;
	//public int pointsForKill;
	private float time;
	private Vector2 direction;
	private Vector2 velocity; 
	private float rotationSpeed;

	private Rigidbody2D myRigidBody;
	private float waitToReload;
	private bool reloading;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Player = GameObject.Find ("Player").transform;
		myRigidBody = GetComponent<Rigidbody2D>(); 
		direction = Player.transform.position - transform.position;
		direction.Normalize ();
		velocity = direction * speed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		myRigidBody.velocity = new Vector2 (velocity.x, velocity.y);
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
		/*if (other.gameObject.name == "Player") {
			other.gameObject.SetActive (false);
			reloading = true;
			thePlayer = other.gameObject;
		}*/

		if (other.gameObject.name == "Collision") {
			Destroy (gameObject);
		}
	}
}
