using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLevelDirector : MonoBehaviour {
    public levelParameters[] levels;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public ArrayList create_enemy(int level)
    {
        levelParameters the_level = levels[level];

        //Addition
        return initilize_question_addition(the_level.min_answer_add, 
            the_level.max_answer_add, the_level.num_decimals_add);
    }

    public ArrayList initilize_question_addition(float min_answer, float max_answer, int num_decimals=0)
    {
        float new_correct_answer = Mathf.Round(Random.Range(min_answer, max_answer));
        float first_elem = Mathf.Round(Random.Range(1, new_correct_answer));
        float second_elem = new_correct_answer - first_elem;

        ArrayList arr = new ArrayList();
        arr.Add(first_elem.ToString() + "+" + second_elem.ToString() + "=");
        arr.Add(new_correct_answer.ToString());

        return arr;
    }
}
