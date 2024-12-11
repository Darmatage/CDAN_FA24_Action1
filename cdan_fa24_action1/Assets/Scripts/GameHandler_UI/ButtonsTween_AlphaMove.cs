using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class ButtonsTween_AlphaMove : MonoBehaviour{
       public AnimationCurve curveMove = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
       public AnimationCurve curveAlpha = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
       float elapsed = 0f;
       float elapsedMove = 0f;
       Image thisImage;
       //public TextMeshProUGUI buttonText;
	   public Text buttonText;

       public bool isButton1 = false;
       bool doButton1 = false;
       public bool isButton2 = false;
       bool doButton2 = false;
       public bool isButton3 = false;
       bool doButton3 = false;

       float timer = 0;
       float button1Timer = 0.5f;
       float button2Timer = 1.5f;
       float button3Timer = 2f;

       float preOffsetPosY;
       float startOffset = -100f;
       Vector3 startButtonPos;

	//Effects:
	private AudioSource scrapeSFX;
	public UI_Shake UI_toShake;
	public bool canShake = true;

	void Start(){
		preOffsetPosY = transform.position.y; //save the destination
		startButtonPos = transform.position;
		startButtonPos.y += startOffset;
		transform.position = startButtonPos; //set the start position

		thisImage = GetComponent<Image>();
		thisImage.color = new Color(2.55f, 2.55f, 2.55f, 0f);
		//buttonText = GetComponentInChildren<TextMeshProUGUI>();
		buttonText = GetComponentInChildren<Text>();
		buttonText.color = new Color(2.55f, 2.55f, 2.55f, 0f);

		scrapeSFX = GetComponent<AudioSource>();
		
    }

	void FixedUpdate () {
		timer += Time.deltaTime;
		if (timer >= button1Timer){
			doButton1=true; 
			scrapeSFX.Play();
			if (isButton1){
				ShakeUI();
			}
		}
		if (timer >= button2Timer){
			doButton2=true; 
			scrapeSFX.Play();
			if (isButton2){
				ShakeUI();
			}
		}
		if (timer >= button3Timer){
			doButton3=true; 
			scrapeSFX.Play();
			if (isButton3){
				ShakeUI();
			}
		}

		if (
			((isButton1) && (doButton1))
			|| ((isButton2) && (doButton2))
			|| ((isButton3) && (doButton3))
		){
			// Tween Move up:
			if(startButtonPos.y <= preOffsetPosY){
				startButtonPos.y += curveMove.Evaluate(elapsedMove) * startOffset *-1;
				transform.position = startButtonPos;
			}

					 //Tween move down:
					 /*
					 if(startButtonPos.y >= preOffsetPosY){
                            startButtonPos.y -= curveMove.Evaluate(elapsedMove) * startOffset;
                            transform.position = startButtonPos;
                     }
					 */
					
                    
                     // Tween Alpha:
                     if (elapsed <= 1f){
                            float newAlpha = curveAlpha.Evaluate(elapsed);
                            thisImage.color = new Color(2.55f, 2.55f, 2.55f, newAlpha);
                            buttonText.color = new Color(2.55f, 2.55f, 2.55f, newAlpha);
			}
			elapsed += Time.deltaTime;
			elapsedMove += (Time.deltaTime / 10f);
		}
	}

	void ShakeUI(){
		if (canShake) {
				Debug.Log("shaking camera");
				UI_toShake.ShakeThis(0.4f, 8f);
				canShake = false;
		}
	}

	
}