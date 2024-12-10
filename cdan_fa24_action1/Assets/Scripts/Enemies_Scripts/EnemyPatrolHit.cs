using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyPatrolHit : MonoBehaviour {

       public float speed = 2f;
       private Rigidbody2D rb;
       private Animator anim;
       public LayerMask groundLayer;
       public LayerMask wallLayer;
       public Transform groundCheck;
       public bool faceRight = true;
       RaycastHit2D hitDwn;
       RaycastHit2D hitSide1;
		RaycastHit2D hitSide2;
       public float raylength = 1f;

       public int damage = 10;
       private GameHandler gameHandler;

       void Start(){
              rb = GetComponent<Rigidbody2D>();
              anim = GetComponentInChildren<Animator>();
              if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
              anim.SetBool("Walk", true);
       }

    void Update(){
      hitDwn = Physics2D.Raycast(groundCheck.position, -transform.up, raylength, groundLayer);
      hitSide1 = Physics2D.Raycast(groundCheck.position, transform.right, raylength/2, wallLayer);
	  hitSide2 = Physics2D.Raycast(groundCheck.position, -transform.right, raylength/2, wallLayer);

	  //Debug.DrawRay(hitDwn.origin, hitDwn.direction * raylength, Color.green);
	  //Debug.DrawLine(hitDwn.origin, hitDwn.point, Color.red);
	  Debug.DrawRay(groundCheck.position, -transform.up * raylength, Color.green);
	  Debug.DrawRay(groundCheck.position, transform.right * raylength/2, Color.red);
	  Debug.DrawRay(groundCheck.position, -transform.right * raylength/2, Color.red);
    }

       void FixedUpdate(){
         if (GetComponent<EnemyMeleeDamage>().isDead==false){
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
              if ((hitSide1.collider != false)||(hitSide2.collider != false)){
                     Debug.Log("I hit a wall");
                     faceRight = !faceRight;
                     transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
              }
            }
       }

       public void OnCollisionEnter2D(Collision2D other){
              if (other.gameObject.tag == "Player") {
                     //anim.SetBool("Attack", true);
                     //gameHandler.playerGetHit(damage);
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
