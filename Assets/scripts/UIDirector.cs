using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDirector : MonoBehaviour {
    private int num_lives = 0;
    private int score = 0;
    private int level = 0;
    public Text life_text;
    public Text level_text;
    public Text score_text;

    public GameObject player_parameter_canvas;
    public GameObject level_up_canvas;

    private canvasLevelUpDirector canvas_level_up;

    void Start () {
        show_level();
        show_lives();
        show_score();
        canvas_level_up = level_up_canvas.GetComponent<canvasLevelUpDirector>();
	}

    private void show_lives()
    {
        life_text.text = "Lives: " + num_lives.ToString();
    }

    public void set_lives(int num)
    {
        num_lives = num;
        show_lives();
    }

    private void show_score()
    {
        score_text.text = "Score: " + score.ToString();
    }

    public void set_score(int num)
    {
        score = num;
        show_score();
    }

    private void show_level()
    {
        level_text.text = "Level: " + level.ToString();
    }

    public void set_level(int num)
    {
        level = num + 1;
        show_level();
    }

    public void show_level_up(string name, string message){
        player_parameter_canvas.SetActive(false);
        level_up_canvas.SetActive(true);
        canvas_level_up.set_name(name);
        canvas_level_up.set_message(message);
    }

    public void disable_all_menus(){
        player_parameter_canvas.SetActive(true);
        level_up_canvas.SetActive(false);
    }
}
