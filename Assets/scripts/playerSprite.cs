using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerSprite : MonoBehaviour {
    Animator animator;
    public float player_sprite_speed = 1f;
    string spell_trigger = "do_spell";
    string idle_anim_name = "kyap_idle";
    private Vector3 target_pos;
    void Start(){
        animator = GetComponent<Animator>();
    }

	void Update () {
		float step = player_sprite_speed * Time.deltaTime;

        // Move our position a step closer to the target.
        if(animator.GetCurrentAnimatorStateInfo(0).IsName(idle_anim_name)){
            this.transform.position = Vector3.MoveTowards(this.transform.position, target_pos, step);
        }
	}

    public void change_target_pos(Vector3 _target_pos){
        target_pos = new Vector3(this.transform.position.x, 
                                _target_pos.y, 
                                this.transform.position.z);
    }

    public void cast_spell(){
        animator.SetTrigger(spell_trigger);
    }
}