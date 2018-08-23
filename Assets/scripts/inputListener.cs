using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputListener : MonoBehaviour {
    public gameDirector parent_director;

    private string current_answer_s = "";
    private float current_answer_f = 0f;
    // Use this for initialization
    void Start () {
        set_current_answer_zero();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                if (current_answer_s != "")
                {
                    parent_director.send_answer(current_answer_s);
                    set_current_answer_zero();
                }
            }
            else if (Input.GetKeyDown("backspace"))
            {
                if (current_answer_s.Length > 0)
                {
                    current_answer_s = current_answer_s.Substring(0, current_answer_s.Length - 1);
                    if (!float.TryParse(current_answer_s + Input.inputString, out current_answer_f))
                    {
                        current_answer_f = 0;
                    }
                }
                parent_director.update_answer(current_answer_s);

            }
            else if (float.TryParse(current_answer_s + Input.inputString, out current_answer_f))
            {
                current_answer_s = current_answer_s + Input.inputString;
                parent_director.update_answer(current_answer_s);
            }
        }
    }

    public void set_current_answer_zero()
    {
        current_answer_s = "";
        current_answer_f = 0f;
    }
}
