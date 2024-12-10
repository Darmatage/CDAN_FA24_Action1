using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_VelocityAttack : MonoBehaviour{

	public float currentVelocity;
	public float attackVelocity = 10f;
	private Rigidbody2D rb2D;
	private GameHandler gameHandler;
	private CameraShake cameraShake; 
	public GameObject smackDownStarPrefab;

    void Start(){
        rb2D=GetComponent<Rigidbody2D>();
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		cameraShake = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }

	//check the velocity magnitude:
    void Update(){
		currentVelocity = rb2D.velocity.magnitude;
    }

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag=="enemy"){
			Debug.Log("Player Velocity on Impact: " + currentVelocity);
			//if fast enough, kill enemy:
			if (currentVelocity >= attackVelocity){
				Instantiate (smackDownStarPrefab, transform.position, Quaternion.identity);
				gameHandler.playerKillEnemy(1);
				EnemyMeleeDamage enemy = other.gameObject.GetComponent<EnemyMeleeDamage>();
				enemy.TakeDamage(enemy.maxHealth + 1);
				cameraShake.ShakeCamera(0.15f, 0.3f);
				//Destroy(other.gameObject);
			}
			//otherwise, hurt player:
			else {
				gameHandler.playerGetHit(10);
			}
		}
	}

}
