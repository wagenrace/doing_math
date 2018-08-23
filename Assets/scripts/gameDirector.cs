using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameDirector : MonoBehaviour {
    [Header("Game Parameters")]
    public int lives = 3;
    public int level = 1;
    public int score = 0;

    public int correct_answer_added_score = 100;
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
        Debug.Log("Firing " + answer.ToString());
    }

    public void update_answer(string answer)
    {
        Debug.Log("answer is" + answer.ToString());
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
        ui_director.set_score(score);
    }

    public void send_correct_answer()
    {
        change_score(correct_answer_added_score);
    }

    public void send_incorrect_answer()
    {
        change_lives(-1);
    }
}
