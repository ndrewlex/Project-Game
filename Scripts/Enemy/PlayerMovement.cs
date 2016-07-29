using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
	public Text LivesText;
	public Vector2 playerPos;
	private int maxSkill = 2;
	public float moveSpeed;
	private bool status;
	private Animator anim;
	private ScoreManager score;
	private Rigidbody2D myRigidbody;
	public bool playerMoving;
	public Skill skill;
	public Transform LaunchPoint ;
	public GameObject trap;
	private Vector2 lastMove;
	public int lives ;
	public float waitToReload;
	private bool reloading;
	private float duration;
	private float durationCounter;
	// Use this for initialization
	void Start () 
	{
		score = FindObjectOfType<ScoreManager>();
		status = false;
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D> ();
		skill = GetComponent<Skill> ();
		durationCounter = duration;
		lives = 1;
		LivesText.text = "Lives : " +lives ;
	}

	// Update is called once per frame
	void Update () 
	{
		if(durationCounter<0f)
		{
			moveSpeed = 3.0f;
		}
		else if(durationCounter>=0.0f)
		{
			durationCounter -= Time.deltaTime;
		}
			
		playerPos = new Vector2(this.transform.position.x, this.transform.position.y);
		playerMoving = false;
		if(Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f )
		{
			//transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f,0f));
			myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2(Input.GetAxisRaw("Horizontal"),0f);
		}
		else if(Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f )
		{
			//transform.Translate (new Vector3(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,0f));
			myRigidbody.velocity = new Vector2( myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
			playerMoving = true;
			lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical")); 
		}

		if(Input.GetAxisRaw("Horizontal")< 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
		{
			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
		}
		if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f )
		{
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);	
		}
		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	
		if (reloading) {
			//theScore.scoreIncreasing = false;
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				Application.LoadLevel (3);
				return;
				score.scoreCount = 0;
				score.scoreIncreasing = true;
				//thePlayer.SetActive (true);
			}
			
			//theScore.scoreCount = 0;
			//theScore.scoreIncreasing = true;
		}
	}
	
	public int getLives()
	{
		return lives;
	}
	
	public void setMoveSpeed(float moveSpeed)
	{
		this.moveSpeed = moveSpeed;
	}

	/*void setGameOver()
	{
		Application.LoadLevel (3);
		score.
	}*/
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if ( other.gameObject.name == "SkillBox(Clone)")
		{
			if ( Random.Range (0, maxSkill) == 0)
			{
				durationCounter = 5f;
				moveSpeed = 6.0f;
				LivesText.text = "Lives : " +lives ;
			}
			else if(Random.Range (0, maxSkill) == 1)
			{
				durationCounter = 5f;
				lives += 1;
				LivesText.text = "Lives : " +lives ;
			}
			if(Random.Range (0, maxSkill) == 2)
			{
				durationCounter = 5f;
				Instantiate (trap, LaunchPoint.position, LaunchPoint.rotation);
				LivesText.text = "Lives : " +lives ;
			}
		}
		
		else if(other.gameObject.name == "Archer" || other.gameObject.name == "Archer(Clone)")
		{
			lives -=1;
			LivesText.text = "Lives : " +lives ;
			if(lives > 0)
			{
				reloading = false;
			}
			else if( lives == 0)
			{
				score.scoreIncreasing = false;
				reloading = true;
				other.gameObject.SetActive (false);
			}
			//thePlayer = other.gameObject;
		}
		else if(other.gameObject.name == "Goblin Sword" || other.gameObject.name == "Goblin Sword(Clone)")
		{
			lives -=1;
			LivesText.text = "Lives : " +lives ;
			if(lives > 0)
			{
				reloading = false;
			}
			else if( lives == 0)
			{
				score.scoreIncreasing = false;
				reloading = true;
				other.gameObject.SetActive (false);
			}
			
			//Application.LoadLevel (3);
			//return;
			//thePlayer = other.gameObject;
		}
		else if(other.gameObject.name == "arrow_Right(Clone)" || other.gameObject.name == "arrow_Left(Clone)" || other.gameObject.name == "arrow_Up(Clone)" || other.gameObject.name == "arrow_Down(Clone)")
		{
			lives -=1;
			LivesText.text = "Lives : " +lives ;
			score.scoreIncreasing = false;
			reloading = true;
			other.gameObject.SetActive (false);
		}
	}
}



