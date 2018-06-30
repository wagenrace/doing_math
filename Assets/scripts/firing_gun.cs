using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firing_gun : MonoBehaviour {
	public InputField inputFieldCo;
	public enemy_director enemy_director;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		inputFieldCo.ActivateInputField();
		if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
			enemy_director.getting_hit(inputFieldCo.text);
			inputFieldCo.text = "";
		}
	}
}
