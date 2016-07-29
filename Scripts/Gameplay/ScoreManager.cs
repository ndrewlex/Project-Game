using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text hiScoreText;
	
	// Use this for initialization

	public float scoreCount;
	public float hiScoreCount;
	public float pointsPerSecond;
	public bool scoreIncreasing;

	void Start () 
	{
		
	}


	// Update is called once per frame
	void Update () {

		if (scoreIncreasing) {
			scoreCount += pointsPerSecond * Time.deltaTime;
		}
		scoreText.text = "Score :  " + Mathf.Round (scoreCount);
	}
}
