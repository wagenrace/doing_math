using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_orchastetor : MonoBehaviour {
	private int num_lives = 0;
	private int score = 0;
	private int level = 0;
	public Text life_text;
	public Text level_text;
	public Text score_text;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void change_lives(int dif = -1){
		num_lives += dif;
		show_lives();
	}

	private void show_lives(){
		life_text.text = "Lives: " + num_lives.ToString();
	}

	public void set_lives(int num){
		num_lives = num;
		show_lives();
	}

	public void change_score(int dif = 0){
		score += dif;
		show_score();
	}

	private void show_score(){
		score_text.text = "Score: " + score.ToString();
	}

	public void set_score(int num){
		score = num;
		show_score();
	}

	public void change_level(int dif = 1){
		level += dif;
		show_level();
	}

	private void show_level(){
		level_text.text = "Level: " + level.ToString();
	}

	public void set_level(int num){
		level = num;
		show_level();
	}
}
