using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirector : MonoBehaviour {
    public int max_num_enemies_simultaneously = 2;
	public float delta_t_enemy_creation = 5f; 	
    public GameObject enemy_object;
	public gameDirector the_director;
    public enemyLevelDirector level_director;
    private int current_level;
	private string correct_answer;
	private enemyObject enemy_ahead;
	private float t_last_enemy_created = 0f;
	private float y_last_enemy;
	private float y_dif_enemy = 0.24f;
	private float y_max_enemy = 0.7f;
	private float y_min_enemy = 0.1f;
	private int numb_enemies = 0;
	// Use this for initialization
	void Start () {
		y_last_enemy = y_min_enemy;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//The time the last enemy was created
		float time_dif = Time.time - t_last_enemy_created;
		
		//Check if new enemy needs to be made
		if(transform.childCount < max_num_enemies_simultaneously && time_dif > delta_t_enemy_creation){
			create_new_enemy();
		}
		if(numb_enemies == 0){
			create_new_enemy();
		}

		//find out what is a ahead
		detect_first_enemy();
	}

	void create_new_enemy(){
        
		GameObject s = Instantiate(enemy_object) as GameObject;
		s.transform.SetParent(this.transform);
		float new_y_enemy = (y_last_enemy + y_dif_enemy - y_min_enemy) % (y_max_enemy - y_min_enemy) + y_min_enemy;
		s.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.8f,new_y_enemy,1f));
        y_last_enemy = new_y_enemy;
        ArrayList arr = level_director.create_enemy(current_level);
        s.GetComponent<enemyObject>().initilize_question(this, arr[0].ToString(), arr[1].ToString());
		
		//Set time of last enemy created to current time
		t_last_enemy_created = Time.time;
		detect_first_enemy();
	}

	void detect_first_enemy(){
		float? min_x = null;
		numb_enemies = 0;
		for(int i = 0; i < transform.childCount; i++){
			Transform Go = transform.GetChild(i);
			enemyObject _current_enemie = Go.GetComponent<enemyObject>();
			if(!_current_enemie.is_alive){
				continue;
			}
			numb_enemies++;
			if(min_x == null){
				min_x = Go.transform.position.x;
				update_enemy_ahead(_current_enemie);
			}else{
				if(min_x > Go.transform.position.x){
					min_x = Go.transform.position.x;
					update_enemy_ahead(_current_enemie);
				}
			}
		}
	}

	private void update_enemy_ahead(enemyObject i){
		enemy_ahead = i;
		the_director.change_enemy_ahead(enemy_ahead);
	}

	public void correct_answer_sended(){
		the_director.correct_answer_sended();
	}

	public void incorrect_answer_sended(){
		the_director.incorrect_answer_sended();
	}

	public void send_answer(string answer)
    {
        enemy_ahead.send_answer(answer);
    }

    public void update_answer(string answer)
    {	
        enemy_ahead.update_answer(answer);
    }

    public void set_level(int _level)
    {
        current_level = _level;
		destroy_all_enemies();
    }

	public void destroy_all_enemies(){
        for(int i = 0; i < transform.childCount; i++){
			Transform Go = transform.GetChild(i);
            Go.GetComponent<enemyObject>().self_destruct();
        }
	}
}
