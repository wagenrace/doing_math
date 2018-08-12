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
	public GameObject player_sprite;
	public float player_sprite_speed = 1f;

	private AudioManager audio_manager;
	private Transform first_enemy;
	private Vector3 target_pos;
	// Use this for initialization
	void Start () {
		show_lives();
		show_score();
		show_level();
		audio_manager = FindObjectOfType<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		float step = player_sprite_speed * Time.deltaTime;

        // Move our position a step closer to the target.
        player_sprite.transform.position = Vector3.MoveTowards(player_sprite.transform.position, target_pos, step);
	}

	public void set_first_enemy(Transform i){
		first_enemy = i;
		target_pos = new Vector3(player_sprite.transform.position.x, first_enemy.transform.position.y, player_sprite.transform.position.z);
	}
	public void substract_life(int num = 1){
		number_lifes -= num;
		audio_manager.Play("incorrect_answer");
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
