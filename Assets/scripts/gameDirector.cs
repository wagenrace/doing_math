using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameDirector : MonoBehaviour {
    [Header("Game Parameters")]
    public int lives = 3;
    public int level_num = 0;
    public int score = 0;

    public int correct_answer_added_score = 100;
    public int incorrect_answer_added_score = -500;
    [Header("Sub Director")]
    public UIDirector ui_director;
    public enemyDirector enemy_director;
    public inputListener input_listener;
    public gameLevelDirector level_director;
    public playerDirector player_director;
	public AudioManager audio_director;
    private levelParametersGame current_level;
    private enemyObject enemy_ahead;
    void Start () {
        ui_director.set_lives(lives);
        ui_director.set_level(level_num);
        ui_director.set_score(score);
        current_level = level_director.check_current_level(score);
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

    public void change_score(int dif = 100)
    {
        score += dif;
        if(score < 0){
            score = 0;
        }
        ui_director.set_score(score);
        check_current_level();
    }

    public void change_enemy_ahead(enemyObject _i){
        enemy_ahead = _i;
        player_director.change_first_enemy(enemy_ahead);
    }
    public void correct_answer_sended()
    {
        audio_director.Play("correct_answer");
        empty_input();
        change_score(correct_answer_added_score);
    }

    public void incorrect_answer_sended()
    {
        audio_director.Play("incorrect_answer");
        empty_input();
        change_score(incorrect_answer_added_score);
    }

    void check_current_level()
    {
        levelParametersGame new_level = level_director.check_current_level(score);
        if(new_level != current_level)
        {
            change_level(new_level);
        }
    }

    public void change_level(levelParametersGame new_level)
    {
        audio_director.Play("level_up");
        Time.timeScale = 0f; 
        current_level = new_level;
        level_num = current_level.get_level();
        enemy_director.change_level(level_num);
        ui_director.set_level(level_num);
        ui_director.show_level_up(current_level.name, current_level.message);
        Debug.Log("new level researched");
    }

    public void activate_game(){
        Time.timeScale = 1f; 
        ui_director.disable_all_menus();
    }

    public void dead_zone_trigged(){
        audio_director.Play("incorrect_answer");
        Debug.Log("dead_zone is triggered 2");
        change_lives(-1);
        empty_input();
    }

    private void empty_input(){
        update_answer(string.Empty);
        input_listener.set_current_answer_zero();
    }
}
