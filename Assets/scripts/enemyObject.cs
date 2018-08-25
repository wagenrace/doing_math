using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyObject : MonoBehaviour {
    private enemyDirector the_director;
    private string correct_answer;
    void start(){

    }

    void update(){
		transform.Translate(direction_vector * moveSpeed * Time.deltaTime);
    }

    void set_director(enemyDirector new_director){
        the_director = new_director;
    }

    void set_question(string question){
        GetComponent<TextMesh>().text = question;
    }

    void set_correct_answer(string answer){
        correct_answer = answer;
    }

    public void send_answer(float answer){
		if(answer == correct_answer){
            the_director.correct_answer_sended();
			FindObjectOfType<AudioManager>().Play("correct_answer");
			Destroy(this.gameObject);
		}else{
			FindObjectOfType<AudioManager>().Play("incorrect_answer");
			the_director.in_correct_answer_sended();
		}
	}
}