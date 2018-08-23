using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_zone : MonoBehaviour {
	public enemy_director enemy_director;
	public game_orchastetor the_orchastetor;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if((other.gameObject.GetComponent("enemy_movement") as enemy_movement) != null){
			the_orchastetor.change_lives(-1);
			enemy_director.dead_zone_trigged();
        	Destroy(other.gameObject);
		}
    }
}
