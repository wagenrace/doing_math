using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadZone : MonoBehaviour {
    public gameDirector game_director;

    void OnTriggerEnter2D (Collider2D other){
		if((other.gameObject.GetComponent("enemyObject") as enemyObject) != null){
			game_director.dead_zone_trigged();
      other.gameObject.GetComponent<enemyObject>().dead_zone_trigged();
		}
    }
}