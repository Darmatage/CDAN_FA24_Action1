using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_VelocityAttack : MonoBehaviour{

	public float currentVelocity;
	public float attackVelocity=2f;
	private Rigidbody2D rb2D;
	private GameHandler gameHandler;

    // Start is called before the first frame update
    void Start(){
        rb2D=GetComponent<Rigidbody2D>();
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update(){
		currentVelocity = rb2D.velocity.magnitude;
    }

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag=="enemy"){
			//if fast enough, kill enemy:
			if (currentVelocity >= attackVelocity){
				gameHandler.playerKillEnemy(1);
				Destroy(other.gameObject);
			}
			//otherwise, hurt player:
			else {
				gameHandler.playerGetHit(10);
			}
		}
	}

}
