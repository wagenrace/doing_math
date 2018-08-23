using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard_input : MonoBehaviour {
	public int max_characters = 5;
	public bool letters_allowed = false;
	public bool numbers_allowed = true;
	private string text = "";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

    	
	}
	/*
	void send_text(){
		Debug.Log(text);
		text = "";
	}

	void update_text(char i){
		text = text + i.ToLower();
		GetComponent<TextMesh>().text = text;
	}
	*/
}
