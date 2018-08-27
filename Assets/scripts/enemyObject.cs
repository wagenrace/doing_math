using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyObject : MonoBehaviour {
    private enemyDirector the_director;
    private string correct_answer = "2";
    private string question = "1+1=";
    private float moveSpeed = 1f;
    private Vector3 direction_vector = new Vector3(-1f, 0f, 0f);

    void awake(){
        Debug.Log("I am ALIVE!!");
        set_text(question); //TODO remove this
    }

    void update(){
		transform.Translate(direction_vector * moveSpeed * Time.deltaTime);
    }

    public void set_director(enemyDirector new_director){
        the_director = new_director;
    }

    void set_text(string question){
        GetComponent<TextMesh>().text = question;
    }

    void set_correct_answer(string answer){
        correct_answer = answer;
    }

    public void update_answer(string current_input){
        Debug.Log("Enemy objects updates answer to" + current_input);
        set_text(question + current_input);
    }

    public void send_answer(string answer){
		if(answer == correct_answer){
            the_director.correct_answer_sended();
			Destroy(this.gameObject);
		}else{
			the_director.incorrect_answer_sended();
		}
	}
}