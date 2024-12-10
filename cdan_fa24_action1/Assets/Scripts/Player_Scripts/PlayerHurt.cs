using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHurt: MonoBehaviour{
	private Rigidbody2D rb2D;

//Color change:
	private SpriteRenderer rend;
	private Color rendColor;
	public float timeToShowHurt = 0.5f;

      void Start(){
           rb2D = transform.GetComponent<Rigidbody2D>();
		   rend = GetComponentInChildren<SpriteRenderer>();
		   rendColor = rend.color; 
      }

	public void playerHit(){
		GetComponent<Player_AnimationManager>().animHead1.SetTrigger ("Hurt");
		GetComponent<Player_AnimationManager>().animTorso1.SetTrigger ("Hurt");

		GetComponent<Player_AnimationManager>().animHead2.SetTrigger ("Hurt");
		GetComponent<Player_AnimationManager>().animTorso2.SetTrigger ("Hurt");

		rend.material.color = new Color(2.4f, 0.9f, 0.9f, 1f);
		StartCoroutine(ResetColor());
	}

	public void playerDead(){
		rb2D.isKinematic = true;
		GetComponent<Player_AnimationManager>().animHead1.SetTrigger ("Dead");
		GetComponent<Player_AnimationManager>().animTorso1.SetTrigger ("Dead");
		//anim.SetTrigger ("Dead");
	}

	IEnumerator ResetColor(){
		yield return new WaitForSeconds(timeToShowHurt);
		rend.material.color = rendColor;
	}

}
