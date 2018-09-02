using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirector : MonoBehaviour {
	public GameObject enemy_object;
	public gameDirector the_director;
    public enemyLevelDirector level_director;
	public int max_num_enemies_simultaneously = 2;
	public float delta_t_enemy_creation = 5f; 

    private int current_level;
	private string correct_answer;
	private enemyObject enemy_ahead;
	private long t_last_enemy_created = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//The time the last enemy was created
		long elapsedTicks = (long)System.DateTime.Now.Ticks - t_last_enemy_created;
		System.TimeSpan elapsedSpan = new System.TimeSpan(elapsedTicks);
		
		//Check if new enemy needs to be made
		if(transform.childCount < max_num_enemies_simultaneously && elapsedSpan.TotalSeconds > delta_t_enemy_creation){
			create_new_enemy();
		}
		if(transform.childCount == 0){
			create_new_enemy();
		}

		//find out what is a ahead
		detect_first_enemy();

	}

	void create_new_enemy(){
        
		GameObject s = Instantiate(enemy_object) as GameObject;
		s.transform.SetParent(this.transform);
		s.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.8f,Random.Range(0.2f, 0.8f),1f));
        
        ArrayList arr = level_director.create_enemy(current_level);
        s.GetComponent<enemyObject>().initilize_question(this, arr[0].ToString(), arr[1].ToString());
		
		//Set time of last enemy created to current time
		t_last_enemy_created = (long)System.DateTime.Now.Ticks;
		detect_first_enemy();
	}

	void detect_first_enemy(){
		float? min_x = null;
		for(int i = 0; i < transform.childCount; i++){
			Transform Go = transform.GetChild(i);
			if(min_x == null){
				min_x = Go.transform.position.x;
				update_enemy_ahead(Go.GetComponent<enemyObject>());
			}else{
				if(min_x > Go.transform.position.x){
					min_x = Go.transform.position.x;
					update_enemy_ahead(Go.GetComponent<enemyObject>());
				}
			}
		}
	}

	private void update_enemy_ahead(enemyObject i){
		enemy_ahead = i;
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
}
