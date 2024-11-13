using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyPatrolHit : MonoBehaviour {

       public float speed = 2f;
       private Rigidbody2D rb;
       //private Animator anim;
       public LayerMask groundLayer;
       public LayerMask wallLayer;
       public Transform groundCheck;
       bool faceRight = true;
       RaycastHit2D hitDwn;
       RaycastHit2D hitFwd;
       public float raylength = 2f;

       public int damage = 10;
       private GameHandler gameHandler;

       void Start(){
              rb = GetComponent<Rigidbody2D>();
              //anim.SetBool("Walk", true);
              if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
       }

    void Update(){
      hitDwn = Physics2D.Raycast(groundCheck.position, -transform.up, raylength, groundLayer);
      hitFwd = Physics2D.Raycast(groundCheck.position, -transform.up, raylength/2, wallLayer);
    }

       void FixedUpdate(){
              if (hitDwn.collider != false){
                     if (faceRight){
                            rb.velocity = new Vector2(speed, rb.velocity.y);
                     } else {
                            rb.velocity = new Vector2(-speed, rb.velocity.y);
                     }
              } else {
                     faceRight = !faceRight;
                     transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
              }
 
              // wall turning:
              if (hitFwd.collider != false){
                     Debug.Log("I hit a wall");
                     faceRight = !faceRight;
                     transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
              }
       }

       public void OnCollisionEnter2D(Collision2D other){
              if (other.gameObject.tag == "Player") {
                     //anim.SetBool("Attack", true);
                     gameHandler.playerGetHit(damage);
                     //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
                     //StartCoroutine(HitEnemy());
              }
       }

       public void OnCollisionExit2D(Collision2D other){
              if (other.gameObject.tag == "Player") {
                     //anim.SetBool("Attack", false);
              }
       }
}