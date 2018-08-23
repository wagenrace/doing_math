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

    void Start () {
        show_level();
        show_lives();
        show_score();
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
        level = num;
        show_level();
    }
}
