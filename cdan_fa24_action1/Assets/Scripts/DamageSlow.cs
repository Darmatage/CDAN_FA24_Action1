using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DamageSlow : MonoBehaviour {

       public int damage = 1;
       public float damageTime = 0.5f;
       private bool isDamaging = false;
       private float damageTimer = 0f;
       private GameHandler gameHandlerObj;

       //quiksand movement:
       private Vector2 playerVelocityStart;
       private Vector2 playerVelocityHalf;
       public float qsAmt = 4f;
       public GameObject pullOutSandPS;

       void Start () {
         if (GameObject.FindWithTag ("GameHandler") != null) {
            gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
         }
       }

       void FixedUpdate(){
          if (isDamaging == true){
              damageTimer += 0.01f;
              if (damageTimer >= damageTime){
                Debug.Log("I AM DAMAGING YOU!!! In Quicksand");
                gameHandlerObj.playerGetHit(damage);
                damageTimer = 0f;
              }
          }
       }

       void OnTriggerStay2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                     isDamaging = true;
                     playerVelocityStart = other.gameObject.GetComponent<Rigidbody2D>().velocity;
                     playerVelocityHalf = new Vector2(playerVelocityStart.x/qsAmt,playerVelocityStart.y/qsAmt);
                     other.gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocityHalf;
              }
       }

       void OnTriggerExit2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                     isDamaging = false;
                     other.gameObject.GetComponent<Rigidbody2D>().velocity = playerVelocityStart;
                     GameObject sandPS = Instantiate (pullOutSandPS, other.gameObject.transform.position, Quaternion.identity);
                     StartCoroutine(DestroyParticles(sandPS));
              }
       }


       IEnumerator DestroyParticles(GameObject PS){
         yield return new WaitForSeconds(1f);
         Destroy(PS);
       }

}
