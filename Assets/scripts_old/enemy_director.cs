﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_director : MonoBehaviour {
	public int max_num_enemies_simultaneously = 2;
	public int max_num_enemies_total = 20;
	public GameObject enemy_GO;
	public float delta_t_enemy_creation = 5f;
    public int level = 1;
	public GameObject target;
    public level_parameters[] levels;

    private int score = 0;
    private float addition_level = 9f;
    private string current_answer_s = "";
	private float current_answer_f = 0f;
	private long t_last_enemy_created = 0;
	private Transform enemy_ahead;
	private int num_enemies_created = 0;
	// Use this for initialization
	void Awake() {

        int level_num = 1;
        foreach(level_parameters l in levels)
        {
            l.level = level_num;
            level_num++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		detect_first_enemy();
		long elapsedTicks = (long)System.DateTime.Now.Ticks - t_last_enemy_created;
		System.TimeSpan elapsedSpan = new System.TimeSpan(elapsedTicks);
		if(num_enemies_created < max_num_enemies_total){
			if(transform.childCount < max_num_enemies_simultaneously && elapsedSpan.TotalSeconds > delta_t_enemy_creation){
				create_new_enemy();
				
			}
			if(transform.childCount == 0){
				create_new_enemy();
			}
		}
		/*
		Taking the answer of 
		 */
        if (Input.anyKeyDown ){
			if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
				getting_hit(current_answer_s);
				current_answer_s= "";
				current_answer_f = 0f;
			}else if (Input.GetKeyDown("backspace")) {
				if(current_answer_s.Length >0){
					current_answer_s = current_answer_s.Substring(0, current_answer_s.Length - 1);
					if(!float.TryParse(current_answer_s + Input.inputString, out current_answer_f)){
						current_answer_f = 0;
					}
				}
				update_answer();
				
			}else if(float.TryParse(current_answer_s + Input.inputString, out current_answer_f)){
				current_answer_s = current_answer_s + Input.inputString;
				update_answer();
			}
		}
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

    public void update_score(int add)
    {
        score += add;
        Debug.Log(score);
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

	private void getting_hit(string value){
		float x = 0f;
		if(float.TryParse(value, out x)){
			enemy_ahead.GetComponent<enemy_movement>().hit(x);
		}
	}

	private void update_answer(){
		enemy_ahead.GetComponent<enemy_movement>().update_answer(current_answer_s);
	}

	public void dead_zone_trigged(){
		current_answer_s = "";
		current_answer_f = 0f;
	}
}