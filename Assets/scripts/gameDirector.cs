using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameDirector : MonoBehaviour {
    [Header("Game Parameters")]
    public int lives = 3;
    public int level = 1;
    public int score = 0;

    public int correct_answer_added_score = 100;
    public int incorrect_answer_added_score = -500;
    [Header("Sub Director")]
    public UIDirector ui_director;
    public enemyDirector enemy_director;
    public inputListener input_listener;
    // Use this for initialization
    void Start () {
        ui_director.set_lives(lives);
        ui_director.set_level(level);
        ui_director.set_score(score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void send_answer(string answer)
    {
        enemy_director.send_answer(answer);
    }

    public void update_answer(string answer)
    {
        enemy_director.update_answer(answer);
    }

    public void change_lives(int dif = -1)
    {
        lives += dif;
        ui_director.set_lives(lives);
    }

    public void change_level(int dif = 1)
    {
        level += dif;
        ui_director.set_level(level);
    }

    public void change_score(int dif = 100)
    {
        score += dif;
        if(score < 0){
            score = 0;
        }
        ui_director.set_score(score);
    }

    public void correct_answer_sended()
    {
        update_answer(string.Empty);
        input_listener.set_current_answer_zero();
        change_score(correct_answer_added_score);
    }

    public void incorrect_answer_sended()
    {
        update_answer(string.Empty);
        input_listener.set_current_answer_zero();
        change_score(incorrect_answer_added_score);
    }

    public void dead_zone_hit(){
        update_answer(string.Empty);
        input_listener.set_current_answer_zero();
        change_lives(-1);
    }
}
