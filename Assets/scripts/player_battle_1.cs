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
		show_lives();
		show_score();
		show_level();
	}
	
	// Update is called once per frame
	void Update () {
				
	}

	public void substract_life(int num = 1){
		number_lifes -= num;
		show_lives();
	}

	private void show_lives(){
		Debug.Log("number of lifes is " + number_lifes);
		life_text.text = "Lives: " + number_lifes.ToString();
	}

	public void update_score(int num = 0){
		score += num;
		show_score();
	}

	private void show_score(){
		score_text.text = "Score: " + score.ToString();
	}

	public void update_level(int num = 1){
		number_lifes += num;
		show_level();
	}

	private void show_level(){
		level_text.text = "Level: " + level.ToString();
	}
}
