using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Jar : MonoBehaviour{

    private GameHandler gameHandler;

	//allow only one hit:
	private bool hasHit = false;

	//player velocity for jars:
	private float playerVelocity;
	public float velocityMinimum = 5f;

	//EFFECTS:
	public GameObject explodePS;
	private AudioSource explodeSFX;
	/*
	private float clipStartPitch;	//the original note
	private float clipPitch;		//a modified note
	private float clipVolume;		//hold and modify the volume
	*/
	public GameObject SmashStar;
	public GameObject healthPrefab;

    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		explodeSFX = gameObject.GetComponent<AudioSource>();
		/*
		clipStartPitch = explodeSFX.pitch;
		clipPitch = explodeSFX.pitch;
		clipVolume = explodeSFX.volume;
		*/
        //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
    }

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			playerVelocity = other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;

			if (playerVelocity >= velocityMinimum){
				GetComponent<Collider2D>().enabled = false;
				//GetComponent<AudioSource>().Play();
				StartCoroutine(DestroyThis());
			
				if (!hasHit){
					gameHandler.JarsCollected(1);
					Instantiate(explodePS, transform.position, Quaternion.identity);
					other.gameObject.GetComponent<Player_JarBreak>().BreakJarSound();
				/*
					float randPitch = Random.Range(clipPitch/2, clipPitch*2);
					if (!explodeSFX.isPlaying){
						explodeSFX.pitch = randPitch; 
						explodeSFX.Play();
					}
				*/
					//VFX:
					GameObject theStar = Instantiate (SmashStar, transform.position, Quaternion.identity);
					float randSize = Random.Range(0.4f, 0.8f);
					theStar.transform.localScale = new Vector3(randSize, randSize, 1);
				}
				hasHit = true;
			}
        }
	}

	IEnumerator DestroyThis(){
		yield return new WaitForSeconds(0.3f);
		//Random chance of getting a healthpick up:
		int randChance = Random.Range(0,10); 
		if (randChance == 5) {
			Instantiate (healthPrefab, transform.position, Quaternion.identity);
		}
		
		Destroy(gameObject);
	}

}