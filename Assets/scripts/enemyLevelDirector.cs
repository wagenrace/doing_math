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
        return initilize_question_addition(the_level.min_input_add, 
                                           the_level.max_input_add, 
                                           the_level.num_decimals_add);
        }
        randomNumber -= the_level.addition_prop_weight;
        
        if(randomNumber < the_level.substraction_prop_weight)
        {
        return initilize_question_substraction(the_level.min_input_sub, 
                                           the_level.max_input_sub, 
                                           the_level.num_decimals_sub,
                                           allow_negative_answers:the_level.allow_negative_answers
                                           );
        }
        randomNumber -= the_level.substraction_prop_weight;

        Debug.LogWarning("The wheel spon an landed on: NOTHING!!! Addition backup protocal in progress");
        return initilize_question_addition(the_level.max_input_add, 
                                           the_level.max_input_add, 
                                           the_level.num_decimals_add);
    }

    public ArrayList initilize_question_addition(float min_input, float max_input, int num_decimals=0)
    {
        float first_elem = Mathf.Round(Random.Range(min_input, max_input));
        float second_elem = Mathf.Round(Random.Range(min_input, max_input));
        float new_correct_answer = first_elem + second_elem;

        ArrayList arr = new ArrayList();
        arr.Add(first_elem.ToString() + "+" + second_elem.ToString() + "=");
        arr.Add(new_correct_answer.ToString());

        return arr;
    }

    public ArrayList initilize_question_substraction(float min_input, float max_input, int num_decimals=0, bool allow_negative_answers=false)
    {
        
        float rand1 = Mathf.Round(Random.Range(min_input, max_input));
        float rand2 = Mathf.Round(Random.Range(min_input, max_input));
        float first_elem;
        float second_elem;
        float new_correct_answer;
        ArrayList arr = new ArrayList();
        if(allow_negative_answers){
            first_elem = rand1;
            second_elem = rand2;
        }else{
            first_elem = Mathf.Max(rand1, rand2);
            second_elem = Mathf.Min(rand1, rand2);
        }

        new_correct_answer = first_elem - second_elem;
        arr.Add(first_elem.ToString() + "-" + second_elem.ToString() + "=");
        arr.Add(new_correct_answer.ToString());

        return arr;
    }
}
