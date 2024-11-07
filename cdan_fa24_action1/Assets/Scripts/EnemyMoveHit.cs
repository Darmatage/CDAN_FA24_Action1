using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMoveHit : MonoBehaviour {
       public float attackPush = 3.5f;
       public Animator anim;
       public Rigidbody2D rb2D;
       public float speed = 4f;
       private Transform target;
       public int damage = 10;

       public int EnemyLives = 3;
       private GameHandler gameHandler;

       public float attackRange = 10;
       public bool isAttacking = false;
       private float scaleX;

       void Start () {
              anim = GetComponentInChildren<Animator> ();
              rb2D = GetComponent<Rigidbody2D> ();
              scaleX = gameObject.transform.localScale.x;

              if (GameObject.FindGameObjectWithTag ("Player") != null) {
                     target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
              }

              if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
       }

       void Update () {
              float DistToPlayer = Vector3.Distance(transform.position, target.position);

              if ((target != null) && (DistToPlayer <= attackRange)){
                     transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
                    //anim.SetBool("Walk", true);
                    //flip enemy to face player direction. Wrong direction? Swap the * -1.
                    if (target.position.x > gameObject.transform.position.x){
                                   gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
                    } else {
                                    gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
                    }
              }
               //else { anim.SetBool("Walk", false);}
       }

       public void OnCollisionEnter2D(Collision2D other){
              if (other.gameObject.tag == "Player") {
                     isAttacking = true;
                     //anim.SetBool("Attack", true);
                     gameHandler.playerGetHit(damage);
                     //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
                     //StartCoroutine(HitEnemy());

                     //This method teleports the player away from the enemy; can teleport through a wall
                     float pushBack = 0f;
                     if (other.gameObject.transform.position.x > gameObject.transform.position.x){
                            pushBack = 3f;
                     }
                     else {
                            pushBack = -3f;
                     }
                     other.gameObject.transform.position = new Vector3(transform.position.x + pushBack, transform.position.y + 1, 0);
              }
       }

       //DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, attackRange);
       }
}
