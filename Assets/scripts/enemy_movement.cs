using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour {
	public float moveSpeed = 1f;
	public Vector3 direction_vector = new Vector3(-1f, 0f, 0f);
	public float correct_answer = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction_vector * moveSpeed * Time.deltaTime);
	}

	public void hit(float answer){
		if(answer == correct_answer){
			Destroy(this.gameObject);
		}
	}

	public void set_add_whole_num(float level){
		correct_answer = Mathf.Round(Random.Range(2, level));
		float first_elem = Mathf.Round(Random.Range(1, correct_answer));
		float second_elem = correct_answer - first_elem;
		string new_question = first_elem.ToString() + "+" + second_elem.ToString();
		GetComponent<TextMesh>().text = new_question;
		Debug.Log(new_question);
		Debug.Log(correct_answer);
	}
}
