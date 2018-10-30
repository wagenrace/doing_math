using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell_enemy_collision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
      if((other.gameObject.GetComponent("enemyObject") as enemyObject) != null){
        if(other.gameObject.GetComponent<enemyObject>().is_alive){
          other.gameObject.GetComponent<enemyObject>().spell_trigged();
		  self_destruct();
        }
      }
	}

	void self_destruct()
    {
        Destroy(this.gameObject);
    }
}
