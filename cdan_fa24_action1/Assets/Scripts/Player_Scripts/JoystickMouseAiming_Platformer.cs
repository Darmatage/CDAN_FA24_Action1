using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMouseAiming_Platformer : MonoBehaviour{
	
	//AIMING:
   private Rigidbody2D rb;
   private Camera cam;
   private Vector2 mousePos;


   //SHOOTING:
   public GameObject projectilePrefab;
   public Transform shootPoint;
   public Transform shootBase;
   public float projectileSpeed = 10f;

   //Disable MouseControl when using Joystick:
   public bool mouseOn = true;
   private Vector2 mousePosLast; //test mouse position change

   void Awake(){
   //assign rigidbody2D and camera to variables for AIMING:
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
   }

   void Update(){
   //mouse location for AIMING
      mousePos = cam.ScreenToWorldPoint (Input.mousePosition);

   //enable mouse if used
      if (mousePos != mousePosLast){mouseOn = true;}
      mousePosLast = mousePos;

   //add a player Input listener for SHOOTING:
      if (Input.GetButtonUp("Attack")){
         Shoot();
      }
   }

//for AIMING:
   void FixedUpdate(){
   //joystick variables:
      float horizAxis = Input.GetAxis("HorizontalRightStick");
      float vertAxis = Input.GetAxis("VerticalRightStick");
      float directionMultiplier = 1;
   //if JOYSTICK values are non-zero, disable mouse and rotate using joystick:
      if (horizAxis != 0f || vertAxis != 0f){
         mouseOn = false;

      //see if we are facing right or left:
	  /* DOES THIS GAME GAVE A FACE-RIGHT?
         if (gameObject.GetComponent<PlayerMove>().FaceRight){
            directionMultiplier = -1;
         }
         else {directionMultiplier = 1;}
		 */
      //rotate base by joystick input:
         float angle = Mathf.Atan2(horizAxis *directionMultiplier, vertAxis *-1) * Mathf.Rad2Deg;
         shootBase.transform.localEulerAngles = new Vector3(0f, 0f, angle);
      }
   //otherwise, if the mouse is moving, rotate to MOUSE Position:
      else {
         if (mouseOn){
         //rotation uses vector math to calculate angle, then rotates shootBase to mouse
            Vector2 lookDir = mousePos - rb.position;
            //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
         //rb.rotation = angle;
            shootBase.rotation=Quaternion.FromToRotation(Vector3.left * -1, lookDir);
         }
      }
   }


//for SHOOTING:
	void Shoot(){
		Vector2 fwd = (shootPoint.position - shootBase.position).normalized;
		GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D>().AddForce(fwd * projectileSpeed, ForceMode2D.Impulse);
		
	// Calculate the angle and set the bullet's rotation:
		Vector3 direction = (shootPoint.position - shootBase.position).normalized;
		//Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		//rb.velocity = direction * bulletSpeed; // Shoot the bullet in the mouse direction
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		// Adjust by -90 degrees:
		bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
	}

}