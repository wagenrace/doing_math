using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_battle_1 : MonoBehaviour {
	public int number_lifes = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void substract_life(int num = 1){
		number_lifes -= num;
		Debug.Log("number of lifes is " + number_lifes);
	}
}
