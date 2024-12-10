using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

    private GameHandler gameHandler;
    //public playerVFX playerPowerupVFX;
    public bool isHealthPickUp = true;
	public bool isJars = false;
    public bool isSpeedBoostPickUp = false;

    public int healthBoost = 50;
    public float speedBoost = 2f;
    public float speedTime = 2f;

	//allow only one hit:
	private bool hasHit = false;

	//EFFECTS:
	public GameObject explodePS;
	private AudioSource explodeSFX;

    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		explodeSFX = gameObject.GetComponent<AudioSource>();
        //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
			
            GetComponent<Collider2D>().enabled = false;
            //GetComponent<AudioSource>().Play();
            StartCoroutine(DestroyThis());

			if (!hasHit){
				if (isHealthPickUp == true){
					gameHandler.playerGetHit(healthBoost * -1);
					//playerPowerupVFX.powerup();
				}

				if (isJars == true){
					gameHandler.JarsCollected(1);
					Instantiate(explodePS, transform.position, Quaternion.identity);
					explodeSFX.Play();
					//playerPowerupvfx.powerup();
				}

				//if (isSpeedBoostPickUp == true)
				{
					//other.gameObject.GetComponent<PlayerMove>().speedBoost(speedBoost, speedTime);
					//playerPowerupvfx.powerup();
				}
			}
			hasHit = true;
        }

        IEnumerator DestroyThis()
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }

    }

}