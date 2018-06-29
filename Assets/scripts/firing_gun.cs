using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fire_gun : MonoBehaviour {
	private InputField inputFieldCo;
	// Use this for initialization
	void Start () {
		inputFieldCo = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
		
    	Debug.Log(inputFieldCo.text);
	}
}
