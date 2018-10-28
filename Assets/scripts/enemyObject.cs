using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class enemyObject : MonoBehaviour {
    public bool is_alive = true;
    private enemyDirector the_director;
    private string correct_answer;
    private string question;
    private float moveSpeed = 1f;
    private Vector3 direction_vector = new Vector3(-1f, 0f, 0f);

    void FixedUpdate(){
		transform.Translate(direction_vector * moveSpeed * Time.deltaTime);
    }

    void set_director(enemyDirector new_director){
        the_director = new_director;
    }

    void set_question(string _question){
        question = _question;
        set_text(question);
    }

    void set_text(string new_text){
        GetComponent<TextMesh>().text = new_text;
    }

    void set_correct_answer(string answer){
        correct_answer = answer;
    }

    public void update_answer(string current_input){
        set_text(question + current_input);
    }

    public void send_answer(string answer){
		if(answer == correct_answer){
            the_director.correct_answer_sended();
            is_alive = false;
			Invoke("self_destruct", 5);
		}else{
			the_director.incorrect_answer_sended();
		}
	}

    public void initilize_question(enemyDirector _director, string _question, string _answer){
        set_question(_question);
        set_correct_answer(_answer);
        set_director(_director);
        //throw new NotImplementedException("The requested feature is not implemented.");
    }

    public void dead_zone_trigged(){
        self_destruct();
    }
    public void self_destruct()
    {
        Destroy(this.gameObject);
    }
}