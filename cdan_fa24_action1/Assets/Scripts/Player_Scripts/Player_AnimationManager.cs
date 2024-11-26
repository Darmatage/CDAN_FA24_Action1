using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AnimationManager : MonoBehaviour{

	public GameObject player1Torso;
	public GameObject player1Head;

	public GameObject player2Torso;
	public GameObject player2Head;

	public Animator animTorso1;
	public Animator animHead1;
	
	public Animator animTorso2;
	public Animator animHead2;

    void Start(){
        animTorso1 = player1Torso.GetComponent<Animator>();
		animHead1 = player1Head.GetComponent<Animator>();
		animTorso2 = player2Torso.GetComponent<Animator>();
		animHead2 = player2Head.GetComponent<Animator>();
		player1Torso.SetActive(true);
		player1Head.SetActive(true);
		player2Torso.SetActive(false);
		player2Head.SetActive(false);
    }

    void Update(){
        if (Input.GetKey("1")){
			player1Torso.SetActive(true);
			player1Head.SetActive(true);
			player2Torso.SetActive(false);
			player2Head.SetActive(false);
		}
		if (Input.GetKey("2")){
			player1Torso.SetActive(false);
			player1Head.SetActive(false);
			player2Torso.SetActive(true);
			player2Head.SetActive(true);
		}
    }







}
