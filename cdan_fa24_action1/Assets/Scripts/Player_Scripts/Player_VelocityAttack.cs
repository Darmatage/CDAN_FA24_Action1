using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_VelocityAttack : MonoBehaviour{

	public float currentVelocity;
	public float attackVelocity=2f;
	private Rigidbody2D rb2D;
	private GameHandler gameHandler;

    void Start(){
        rb2D=GetComponent<Rigidbody2D>();
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

	//check the velocity magnitude:
    void Update(){
		currentVelocity = rb2D.velocity.magnitude;
    }

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag=="enemy"){
			//if fast enough, kill enemy:
			if (currentVelocity >= attackVelocity){
				gameHandler.playerKillEnemy(1);
				EnemyMeleeDamage enemy = other.gameObject.GetComponent<EnemyMeleeDamage>();
				enemy.TakeDamage(enemy.maxHealth + 1);
				//Destroy(other.gameObject);
			}
			//otherwise, hurt player:
			else {
				gameHandler.playerGetHit(10);
			}
		}
	}

}
