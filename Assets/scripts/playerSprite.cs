using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerSprite : MonoBehaviour {
    public float player_sprite_speed = 1f;
    private Vector3 target_pos;
	void Update () {
		float step = player_sprite_speed * Time.deltaTime;

        // Move our position a step closer to the target.
        this.transform.position = Vector3.MoveTowards(this.transform.position, target_pos, step);
	}

    public void change_target_pos(Vector3 _target_pos){
        target_pos = new Vector3(this.transform.position.x, 
                                _target_pos.y, 
                                this.transform.position.z);
    }
}