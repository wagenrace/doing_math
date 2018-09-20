using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLevelDirector : MonoBehaviour {
    public levelParametersGame[] levels;
    private int num_levels;
	// Use this for initialization
	void Start () {
		num_levels = levels.Length;
        for(int l = 0;l<num_levels; l++)
        {
            levels[l].set_level(l);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public levelParametersGame check_current_level(int score)
    {
        levelParametersGame current_level = levels[0];
        foreach(levelParametersGame level in levels)
        {
            if(score >= level.score_for_this_level){
                current_level = level;
            }
        }
        return current_level;
    }

}
