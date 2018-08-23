using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirector : MonoBehaviour {
	public GameObject enemy_object;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void create_new_enemy(){
		GameObject s = Instantiate(enemy_GO) as GameObject;
		s.transform.SetParent(this.transform);
		s.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.8f,Random.Range(0.2f, 0.8f),1f));
        s.GetComponent<enemy_movement>().the_director = this;
        s.GetComponent<enemy_movement>().set_add_whole_num(addition_level);
		num_enemies_created++;
		t_last_enemy_created = (long)System.DateTime.Now.Ticks;
	}

	void detect_first_enemy(){
		float? min_x = null;
		for(int i = 0; i < transform.childCount; i++){
			Transform Go = transform.GetChild(i);
			if(min_x == null){
				min_x = Go.transform.position.x;
				update_enemy_ahead(Go.transform);
			}else{
				if(min_x > Go.transform.position.x){
					min_x = Go.transform.position.x;
					update_enemy_ahead(Go.transform);
				}
			}
		}
		
		//target.position = Go.transform.position;
		if(transform.childCount == 0){
			target.GetComponent<SpriteRenderer>().enabled = false;
		}else{
			target.GetComponent<SpriteRenderer>().enabled = true;
			target.transform.position = enemy_ahead.transform.position;
		}
	}

	private void update_enemy_ahead(Transform i){
		enemy_ahead = i;
	}
}
