using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell_movement : MonoBehaviour {
	private Vector3 target_pos;
	public float spell_speed = 8f;
	private bool is_moving = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float step = spell_speed * Time.deltaTime;
		if(is_moving){
			this.transform.position = Vector3.MoveTowards(this.transform.position, target_pos, step);
		}
	}

	public void update_target(Vector3 new_pos){
		target_pos = new_pos;
	}
	public void setup(Vector3 current_pos, Vector3 target_pos){
		update_target(target_pos);
		update_current_pos(current_pos);
		is_moving = true;
	}

	void update_current_pos(Vector3 new_pos){
		this.transform.position = new_pos;
	}
}
