using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_object : MonoBehaviour {
	public GameObject player_sprite;
	public float player_sprite_speed = 1f;

	private AudioManager audio_manager;
	private Transform first_enemy;
	private Vector3 target_pos;
	// Use this for initialization
	void Start () {
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
}
