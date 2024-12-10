using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmackDownStar : MonoBehaviour{
   
	void Start(){
		StartCoroutine(RemoveStar());
	}

	void Update(){
		transform.Rotate (new Vector3 (0, 0, 60) * Time.deltaTime);  
	}

    IEnumerator RemoveStar(){
        yield return new WaitForSeconds(0.3f);
		Destroy(gameObject);
    }

}
