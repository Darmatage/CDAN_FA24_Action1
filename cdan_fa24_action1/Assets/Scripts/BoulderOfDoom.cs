using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WallOfDoom : MonoBehaviour {
       //NOTE: this script moves right-ward by default, but turn on isVertical to move upward;
       public float moveDelay = 1f;
       public float moveRate = 100f;
       public bool isVertical = false;
       public bool startMove = false;
       public float moveTimer = 0;
       public Rigidbody2D rb2D;
       public Vector2 forceVector;
       //public GameObject startDoomEffect; //uncomment to spawn a spritesheet or particles on move start
       //private Animator anim; //uncomment for animated wall (rotating spike wheels, roiling fire or lava, etc)
       //public AudioSource startSFX;

       void Start(){
              rb2D = gameObject.GetComponent<Rigidbody2D>();
              //anim = gameObject.GetComponentInChildren<Animator>();
       }

       void FixedUpdate(){
              moveTimer += 0.01f;
              if (moveTimer >= moveDelay){
                     startMove = true;
                     //GameObject startMove = Instantiate (startDoomEffect, transform.position, transform.rotation);
                     //anim.SetBool("deathmotion", true);
                     //startSFX.Play();
              }

              if (startMove == true){
                     float moveForce = moveRate * Time.fixedDeltaTime;
                     if (isVertical == false){
                            forceVector = new Vector2(moveForce, 0);
                     } else if (isVertical == true) {
                            forceVector = new Vector2(0, moveForce);
                     }
                     rb2D.velocity = rb2D.velocity + forceVector;
              }
       }
}
