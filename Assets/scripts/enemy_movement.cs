using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour {
	public float moveSpeed = 1f;
	public Vector3 direction_vector = new Vector3(-1f, 0f, 0f);
	public float correct_answer = 2f;
	public player_battle_1 player;
	public enemy_director the_director;
	private long time_created;
	private string current_answer = "";
	private string question = "";
	// Use this for initialization
	void Start () {
		time_created = (long)System.DateTime.Now.Ticks;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction_vector * moveSpeed * Time.deltaTime);
	}

	public void hit(float answer){
		if(answer == correct_answer){
			long elapsedTicks = (long)System.DateTime.Now.Ticks - time_created;
			System.TimeSpan elapsedSpan = new System.TimeSpan(elapsedTicks);
			Debug.Log("I lived for" + elapsedSpan.TotalSeconds.ToString());
			the_director.update_score(100);
			FindObjectOfType<AudioManager>().Play("correct_answer");
			Destroy(this.gameObject);
		}else{
			FindObjectOfType<AudioManager>().Play("incorrect_answer");
			the_director.update_score(-100);
		}
		update_answer("");
	}

	public void update_answer(string new_answer){
		current_answer = new_answer;
		GetComponent<TextMesh>().text = question + current_answer;
	}
	public void set_add_whole_num(float level){
		correct_answer = Mathf.Round(Random.Range(2, level));
		float first_elem = Mathf.Round(Random.Range(1, correct_answer));
		float second_elem = correct_answer - first_elem;
		question = first_elem.ToString() + "+" + second_elem.ToString() + "=";
		GetComponent<TextMesh>().text = question;
	}
}
