using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_orchastetor : MonoBehaviour {
	public int num_lives = 5;
	public int sorce = 1000;
	public int level = 2;
	public UI_orchastetor UI_orchastetor;

	// Use this for initialization
	void Start () {
		UI_orchastetor.set_lives(num_lives);
		UI_orchastetor.set_score(sorce);
		UI_orchastetor.set_level(level);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
