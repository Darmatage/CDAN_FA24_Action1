using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_VFX_Destroy : MonoBehaviour{
   
	public float timeToDestroy = 5;

	void Start(){
		StartCoroutine(RemoveEffect());
	}


    IEnumerator RemoveEffect(){
        yield return new WaitForSeconds(timeToDestroy);
		Destroy(gameObject);
    }

}
