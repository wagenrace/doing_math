using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_director : MonoBehaviour {
	public int max_num_enemies_simultaneously = 2;
	public int max_num_enemies_total = 20;
	public GameObject enemy_GO;
	public float delta_t_enemy_creation = 5f;
	public float level = 10f;
	public GameObject target;

	private long t_last_enemy_created = 0;
	private Transform enemy_ahead;
	private int num_enemies_created = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		detect_first_enemy();
		long elapsedTicks = (long)System.DateTime.Now.Ticks - t_last_enemy_created;
		System.TimeSpan elapsedSpan = new System.TimeSpan(elapsedTicks);
		if(transform.childCount < max_num_enemies_simultaneously && elapsedSpan.TotalSeconds > delta_t_enemy_creation && num_enemies_created < max_num_enemies_total){
			create_new_enemy();
			t_last_enemy_created = (long)System.DateTime.Now.Ticks;
		}
	}

	void detect_first_enemy(){
		float? min_x = null;
		for(int i = 0; i < transform.GetChildCount(); i++){
			Transform Go = transform.GetChild(i);
			if(min_x == null){
				min_x = Go.transform.position.x;
				enemy_ahead = Go.transform;
			}else{
				if(min_x > Go.transform.position.x){
					min_x = Go.transform.position.x;
					enemy_ahead = Go.transform;
				}
			}
		}
		
		//target.position = Go.transform.position;
		if(transform.GetChildCount() == 0){
			target.GetComponent<SpriteRenderer>().enabled = false;
		}else{
			target.GetComponent<SpriteRenderer>().enabled = true;
			target.transform.position = enemy_ahead.transform.position;
		}
	}

	void create_new_enemy(){
		GameObject s = Instantiate(enemy_GO) as GameObject;
		s.transform.SetParent(this.transform);
		s.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.8f,Random.Range(0.2f, 0.8f),1f));
		s.GetComponent<enemy_movement>().set_add_whole_num(level);
		num_enemies_created++;
	}

	public void getting_hit(string value){
		float x = float.Parse(value);
		enemy_ahead.GetComponent<enemy_movement>().hit(x);
	}
}
