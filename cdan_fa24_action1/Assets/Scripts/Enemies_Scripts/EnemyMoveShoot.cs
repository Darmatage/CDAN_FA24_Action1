using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMoveShoot : MonoBehaviour {

      //public Animator anim;
	  /*
       public float speed = 2f;
       public float stoppingDistance = 4f; // when enemy stops moving towards player
       public float retreatDistance = 3f; // when enemy moves away from approaching player
	   */
       private float timeBtwShots;
       public float startTimeBtwShots = 2;
       public GameObject projectile;
	   public Transform shootBase;
	   public Transform shootPoint;

       private Rigidbody2D rb;
       private Transform player;
       private Vector2 PlayerVect;

       //public int EnemyLives = 30;
       //private Renderer rend;
       //private GameHandler gameHandler;

       public float attackRange = 6;
       public bool isAttacking = false;
       private float scaleX;
	   private bool enemyFaceRight;
	   public GameObject muzzleFlash;

       void Start () {
              Physics2D.queriesStartInColliders = false;
              scaleX = gameObject.transform.localScale.x;

              //rb = GetComponent<Rigidbody2D> ();
              player = GameObject.FindGameObjectWithTag("Player").transform;
              PlayerVect = player.transform.position;

              timeBtwShots = startTimeBtwShots;

              //rend = GetComponentInChildren<Renderer> ();
              //anim = GetComponentInChildren<Animator> ();

              //if (GameObject.FindWithTag ("GameHandler") != null) {
              // gameHander = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              //}
       }

       void Update () {
		if (gameObject.GetComponent<EnemyMeleeDamage>().isDead == false){
              float DistToPlayer = Vector3.Distance(transform.position, player.position);
              if ((player != null) && (DistToPlayer <= attackRange)) {
                     // approach player
					 /*
                     if (Vector2.Distance (transform.position, player.position) > stoppingDistance) {
                            transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
                            if (isAttacking == false) {
                                   //anim.SetBool("Walk", true);
                            }
                            //Vector2 lookDir = PlayerVect - rb.position;
                            //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
                            //rb.rotation = angle;
                     }
					 */
                     // stop moving
					 /*
                     else if (Vector2.Distance (transform.position, player.position) < stoppingDistance && Vector2.Distance (transform.position, player.position) > retreatDistance) {
                            transform.position = this.transform.position;
                            //anim.SetBool("Walk", false);
                     }
					 */

                     // retreat from player
					 /*
                     else if (Vector2.Distance (transform.position, player.position) < retreatDistance) {
                            transform.position = Vector2.MoveTowards (transform.position, player.position, -speed * Time.deltaTime);
                            if (isAttacking == false) {
                                   //anim.SetBool("Walk", true);
                            }
                     }
					 */

					enemyFaceRight = GetComponent<EnemyPatrolHit>().faceRight;
                     //Flip gun to face player direction IF the player is walking opposite. Wrong direction? Swap the * -1.
                     if (
						((player.position.x < shootBase.position.x)&(enemyFaceRight==false))
					 || ((player.position.x > shootBase.position.x)&(enemyFaceRight==true))
					 ){
                            shootBase.localScale = new Vector2(scaleX, shootBase.localScale.y);
                    } else {
                             shootBase.localScale = new Vector2(scaleX * -1, shootBase.localScale.y);
                     }

                     //Timer for shooting projectiles
                     if (timeBtwShots <= 0) {
                            isAttacking = true;
                            //anim.SetTrigger("Attack");
							GameObject flashEffect = Instantiate (muzzleFlash, shootPoint.position, Quaternion.identity);
							flashEffect.transform.localScale = new Vector3(flashEffect.transform.localScale.x/2, flashEffect.transform.localScale.y/2, 1);
                            Instantiate (projectile, shootPoint.position, Quaternion.identity);
                            timeBtwShots = startTimeBtwShots;
                     } else {
                            timeBtwShots -= Time.deltaTime;
                            isAttacking = false;
                     }
              }
		}
       }
/*
       void OnCollisionEnter2D(Collision2D collision){
              //if (collision.gameObject.tag == "bullet") {
              // EnemyLives -= 1;
              // StopCoroutine("HitEnemy");
              // StartCoroutine("HitEnemy");
              //}
              if (collision.gameObject.tag == "Player") {
                     EnemyLives -= 2;
                     StopCoroutine("HitEnemy");
                     StartCoroutine("HitEnemy");
              }
       }

       IEnumerator HitEnemy(){
              // color values are R, G, B, and alpha, each divided by 100
              rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
              if (EnemyLives < 1){
                     //gameControllerObj.AddScore (5);
                     Destroy(gameObject);
              }
              else yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }
	   */

      //DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, attackRange);
       }
}