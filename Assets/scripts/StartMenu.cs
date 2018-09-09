using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
	public string game_scene_name;

	public void start_button(){
		SceneManager.LoadScene(game_scene_name);
	}
}
