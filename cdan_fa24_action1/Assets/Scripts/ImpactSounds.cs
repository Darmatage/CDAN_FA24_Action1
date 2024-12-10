using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSounds : MonoBehaviour {

       private float hits = 0;
       private AudioSource audioClip;    //the actual AudioSource
       private float clipStartPitch;               //the original note
       private float clipPitch;                       //a modified note
       private float clipVolume;                   //hold and modify the volume

       void Awake() {
             //populate the variables
             audioClip = GetComponent<AudioSource>();
             clipStartPitch = audioClip.pitch;
             clipPitch = audioClip.pitch;
             clipVolume = audioClip.volume;
       }

       void OnCollisionEnter2D(Collision2D other){
              //if the impact has enough force, play audio
              if (other.relativeVelocity.magnitude > 5) {
                    audioClip.Play();
                    //increment hits #
                    hits += 1;
                    //if pitch is above 0, lower pitch per hits, lower volume
                    if (clipPitch > 0){
                           clipPitch = (clipStartPitch - (hits/10)); //lower pitch
                           audioClip.pitch = clipPitch;                 //assign to clip
                           audioClip.volume = clipVolume / 2;
                    }
             }
       }
}