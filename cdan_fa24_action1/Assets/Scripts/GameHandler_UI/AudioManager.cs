using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour{

	public AudioSource MenuMusic;
	public AudioSource GameMusic1;
	//public AudioSource GameMusic2;

	private AudioSource theMusic;
	public static float MusicTimeStamp = 0.0f;
	public float currentTimeStamp;

	void Start(){
		//set the music based on scene
		if ((SceneManager.GetActiveScene().name == "MainMenu")
		|| (SceneManager.GetActiveScene().name == "Credits")
		|| (SceneManager.GetActiveScene().name == "EndLose")
		|| (SceneManager.GetActiveScene().name == "EndWin")
		|| (SceneManager.GetActiveScene().name == "SceneLose")
		|| (SceneManager.GetActiveScene().name == "SceneWin")
		){
			theMusic = MenuMusic;
		} else {
			theMusic = GameMusic1;
		}

		//set the time and play
		theMusic.time = MusicTimeStamp;
		theMusic.Play();
	}

	void Update(){
		//keep track of timestamp, to auto-call it in the next scene:
		MusicTimeStamp = theMusic.time;
		currentTimeStamp = theMusic.time;
	}

	//change timestamp (can be called by door code):
	public void SetTimeStamp(){
		MusicTimeStamp = theMusic.time;
	}

}