using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHurt: MonoBehaviour{
	private Rigidbody2D rb2D;

      void Start(){
           rb2D = transform.GetComponent<Rigidbody2D>();
      }

	public void playerHit(){
		GetComponent<Player_AnimationManager>().animHead1.SetTrigger ("Hurt");
		GetComponent<Player_AnimationManager>().animTorso1.SetTrigger ("Hurt");

		GetComponent<Player_AnimationManager>().animHead2.SetTrigger ("Hurt");
		GetComponent<Player_AnimationManager>().animTorso2.SetTrigger ("Hurt");
	}

	public void playerDead(){
		rb2D.isKinematic = true;
		//anim.SetTrigger ("Dead");
	}
}
