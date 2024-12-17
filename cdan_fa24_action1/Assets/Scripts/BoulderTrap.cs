using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrap : MonoBehaviour{

	private Transform player;
	public Transform spawnPoint;
	public GameObject boulderPrefab;
	float playerDistance;
	public float threshold = 20f;

	//prevent multiple release
	bool canRelease = true;

	//timer:
	float theTimer=0;
	float timeToNextBoulder = 3f;

	void Start(){
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}

	void Update(){
		if (canRelease){
			playerDistance = Vector3.Distance(spawnPoint.position, player.position); 

			if (playerDistance <= threshold){
				Instantiate (boulderPrefab, spawnPoint.position, Quaternion.identity);
				canRelease = false;
			}
		}
	}

	void FixedUpdate(){
		if (canRelease==false){
			theTimer += 0.01f;
			if (theTimer >= timeToNextBoulder){
				theTimer=0;
				canRelease = true;
			}
		}

	}


/*
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag=="Player"){
			Instantiate (boulderPrefab, spawnPoint.position, Quaternion.identity);
		}
	}
*/

}
