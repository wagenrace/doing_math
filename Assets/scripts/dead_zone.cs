using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_zone : MonoBehaviour {
	private GameObject parent_player;
	// Use this for initialization
	void Start () {
		if((transform.parent.gameObject.GetComponent("player_battle_1") as player_battle_1) != null){
        	parent_player = this.transform.parent.gameObject;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if((other.gameObject.GetComponent("enemy_movement") as enemy_movement) != null){
			parent_player.gameObject.GetComponent<player_battle_1>().substract_life(1);
        	Destroy(other.gameObject);
		}
    }
}
