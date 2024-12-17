using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Health : MonoBehaviour{

    private GameHandler gameHandler;
    //public playerVFX playerPowerupVFX;

    public int healthBoost = 50;

	//allow only one hit:
	private bool hasHit = false;

	//player velocity for jars:
	private float playerVelocity;
	public float velocityMinimum = 5f;

	//EFFECTS:
	public GameObject explodePS;
	private AudioSource explodeSFX;
	public GameObject SmashStar;

    void Start(){
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		explodeSFX = gameObject.GetComponent<AudioSource>();
    }

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			playerVelocity = other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;

			GetComponent<Collider2D>().enabled = false;
			//GetComponent<AudioSource>().Play();
			StartCoroutine(DestroyThis());
			
			if (!hasHit){
				gameHandler.playerGetHit(healthBoost * -1);
				//playerPowerupVFX.powerup();
				hasHit = true;
			}
        }
	}

	IEnumerator DestroyThis(){
		yield return new WaitForSeconds(0.3f);
		Destroy(gameObject);
	}

}