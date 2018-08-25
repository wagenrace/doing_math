using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirector : MonoBehaviour {
	public GameObject enemy_object;

	private string correct_answer;
	private enemyObject enemy_ahead;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void send_answer(string answer){

	}

	void create_new_enemy(){
		GameObject s = Instantiate(enemy_GO) as GameObject;
		s.transform.SetParent(this.transform);
		s.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.8f,Random.Range(0.2f, 0.8f),1f));
        s.GetComponent<enemyObject>().set_director(this);
        //s.GetComponent<enemyObject>().create_question();
	}

	void detect_first_enemy(){
		float? min_x = null;
		for(int i = 0; i < transform.childCount; i++){enemy_movement
			Transform Go = transform.GetChild(i);
			if(min_x == null){
				min_x = Go.transform.position.x;
				update_enemy_ahead(Go.GetComponent<enemyObject>());
			}else{
				if(min_x > Go.transform.position.x){
					min_x = Go.transform.position.x;
					update_enemy_ahead(Go.GetComponent<enemyObject>());
				}
			}
		}
	}

	private void update_enemy_ahead(enemyObject i){
		enemy_ahead = i;
	}
}
