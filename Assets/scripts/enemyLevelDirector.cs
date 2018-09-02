using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLevelDirector : MonoBehaviour {
    public levelParametersEnemy[] levels;

    public ArrayList create_enemy(int level)
    {
        levelParametersEnemy the_level = levels[level];

        float totalWeight = the_level.addition_prop_weight + the_level.substraction_prop_weight;

        float randomNumber = Random.Range(0, totalWeight);

        //Addition
        if(randomNumber < the_level.addition_prop_weight)
        {
        return initilize_question_addition(the_level.min_answer_add, 
                                           the_level.max_answer_add, 
                                           the_level.num_decimals_add);
        }
        randomNumber -= the_level.addition_prop_weight;
        
        if(randomNumber < the_level.substraction_prop_weight)
        {
        return initilize_question_substraction(the_level.min_answer_sub, 
                                           the_level.max_answer_sub, 
                                           the_level.num_decimals_sub);
        }
        randomNumber -= the_level.substraction_prop_weight;

        Debug.LogWarning("The wheel spon an landed on: NOTHING!!! Addition backup protocal in progress");
        return initilize_question_addition(the_level.min_answer_add, 
                                           the_level.max_answer_add, 
                                           the_level.num_decimals_add);
    }

    public ArrayList initilize_question_addition(float min_answer, float max_answer, int num_decimals=0)
    {
        float new_correct_answer = Mathf.Round(Random.Range(min_answer, max_answer));
        float first_elem = Mathf.Round(Random.Range(1f, new_correct_answer));
        float second_elem = new_correct_answer - first_elem;

        ArrayList arr = new ArrayList();
        arr.Add(first_elem.ToString() + "+" + second_elem.ToString() + "=");
        arr.Add(new_correct_answer.ToString());

        return arr;
    }

    public ArrayList initilize_question_substraction(float min_answer, float max_answer, int num_decimals=0)
    {
        float new_correct_answer = Mathf.Round(Random.Range(min_answer, max_answer));
        float first_elem = Mathf.Round(Random.Range(new_correct_answer, new_correct_answer * 2 - 1f));
        float second_elem = first_elem - new_correct_answer;

        ArrayList arr = new ArrayList();
        arr.Add(first_elem.ToString() + "-" + second_elem.ToString() + "=");
        arr.Add(new_correct_answer.ToString());

        return arr;
    }
}
