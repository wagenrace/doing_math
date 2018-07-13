using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour {
	public float moveSpeed = 1f;
	public Vector3 direction_vector = new Vector3(-1f, 0f, 0f);
	public float correct_answer = 2f;
	public player_battle_1 player;
	private long time_created;
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
			player.update_score(100);
			FindObjectOfType<AudioManager>().Play("correct_answer");
			Destroy(this.gameObject);
		}else{
			FindObjectOfType<AudioManager>().Play("incorrect_answer");
			player.update_score(-100);
		}
	}

	public void set_add_whole_num(float level, player_battle_1 _player){
		player = _player;
		correct_answer = Mathf.Round(Random.Range(2, level));
		float first_elem = Mathf.Round(Random.Range(1, correct_answer));
		float second_elem = correct_answer - first_elem;
		string new_question = first_elem.ToString() + "+" + second_elem.ToString();
		GetComponent<TextMesh>().text = new_question;
	}
}
