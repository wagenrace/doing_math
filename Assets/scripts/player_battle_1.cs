using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_battle_1 : MonoBehaviour {
	public int number_lifes = 3;
	public int score = 0;
	public int level = 1;
	public Text life_text;
	public Text level_text;
	public Text score_text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		life_text.text = "Lives: " + number_lifes.ToString();
		level_text.text = "Level: " + number_lifes.ToString();
		score_text.text = "Score: " + number_lifes.ToString();
	}

	public void substract_life(int num = 1){
		number_lifes -= num;
		Debug.Log("number of lifes is " + number_lifes);
	}
}
