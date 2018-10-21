using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDirector : MonoBehaviour {
	public gameDirector the_director;
	private enemyObject first_enemy;
	private playerSprite player_sprite;
	// Use this for initialization
	void Start(){
		player_sprite = this.GetComponentInChildren<playerSprite>();
	}
	public void change_first_enemy(enemyObject _first_enemy){
		first_enemy = _first_enemy;
		player_sprite.change_target_pos(first_enemy.transform.position);
	}

	public void cast_spell(){
		player_sprite.cast_spell();
	}
}
