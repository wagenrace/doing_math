using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasLevelUpDirector : MonoBehaviour {
    public Text name_text;
    public Text message_text;
	
	public void set_name(string _name){
		name_text.text = _name;
	}

	public void set_message(string _message){
		message_text.text = _message;
	}
}
