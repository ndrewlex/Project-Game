using UnityEngine;
using System.Collections;

/*public class PlayerMovement : MonoBehaviour
 {
	public float moveSpeed;
	private Animator anim;
	private Rigidbody2D myRigidbody;
	private bool playerMoving;
	private Vector2 lastMove;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
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
	}
}
*/

public class PlayerMovement : MonoBehaviour
{
	public Vector2 playerPos;
	public float moveSpeed;
	private Animator anim;
	private Rigidbody2D myRigidbody;
	public bool playerMoving;
	private Vector2 lastMove;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
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
	}
}



