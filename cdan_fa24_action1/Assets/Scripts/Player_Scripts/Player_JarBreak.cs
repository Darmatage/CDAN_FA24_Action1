using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_JarBreak : MonoBehaviour{
	public AudioSource explodeSFX;
	private float clipStartPitch;	//the original note
	private float clipPitch;		//a modified note
	private float clipVolume;		//hold and modify the volume

    // Start is called before the first frame update
    void Start(){
        clipStartPitch = explodeSFX.pitch;
		clipPitch = explodeSFX.pitch;
		clipVolume = explodeSFX.volume;
    }

    public void BreakJarSound(){
		float randPitch = Random.Range(clipPitch/2, clipPitch*2);
		if (!explodeSFX.isPlaying){
			explodeSFX.pitch = randPitch; 
			explodeSFX.Play();
		}
	}
}
