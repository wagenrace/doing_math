using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
	public string game_scene_name;
	public string start_scene_name = "Start_menu";
	public string credits_scene_name = "credits";

	public void start_button(){
		SceneManager.LoadScene(start_scene_name);
	}

	public void credits_button(){
		SceneManager.LoadScene(credits_scene_name);
	}

	public void game_button(){
		SceneManager.LoadScene(game_scene_name);
	}
}
