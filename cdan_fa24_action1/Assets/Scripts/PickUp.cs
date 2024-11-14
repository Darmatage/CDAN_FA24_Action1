using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour{

    public GameHandler gameHandler;
    //public playerVFX playerPowerupVFX;
    public bool isHealthPickUp = true;
    public bool isSpeedBoostPickUp = false;

    public int healthBoost = 50;
    public float speedBoost = 2f;
    public float speedTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        // //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
