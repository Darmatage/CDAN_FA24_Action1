using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Vignette : MonoBehaviour{

	public GameObject theVignette; 
	private bool timeToFadeAway = false;
	private float fadeAlpha = 1f;
	private Color vignetteColor; 

	void Start(){
		theVignette.SetActive(false); 
		vignetteColor = theVignette.GetComponent<Image>().color;
	}

	void FixedUpdate(){
		if (timeToFadeAway){
			fadeAlpha -= 0.01f;
			theVignette.GetComponent<Image>().color = new Color(vignetteColor.r, vignetteColor.g, vignetteColor.b, fadeAlpha);
			if (fadeAlpha <= 0f){fadeAlpha=0f;}
		}
	} 

	//Activate this function from the GameHandler when player is hurt: 
	public void ActivateVignette(){
		theVignette.SetActive(true);
		theVignette.GetComponent<Image>().color = new Color(vignetteColor.r, vignetteColor.g, vignetteColor.b, fadeAlpha);
		StartCoroutine(FadeOut());
	} 

	IEnumerator FadeOut(){
		yield return new WaitForSeconds(0.2f);
		timeToFadeAway = true;
		yield return new WaitForSeconds(1.0f);
		timeToFadeAway = false;
		theVignette.SetActive(false);
		fadeAlpha = 1f;
	} 
}