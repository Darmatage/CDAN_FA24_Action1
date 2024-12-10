using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBottomRespawn : MonoBehaviour
{
    public GameHandler gameHandler;
    public Transform playerPos;
    public Transform pSpawnFall;
    public int damage = 10;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos != null)
        {
            pSpawnFall = playerPos.gameObject.GetComponent<PlayerRespawn>().pSpawn;

            if (transform.position.y >= playerPos.position.y)
            {
                
                gameHandler.playerGetHit(damage);
                Debug.Log("I am going back to start");
                Vector3 pSpn2 = new Vector3(pSpawnFall.position.x, pSpawnFall.position.y, playerPos.position.z);
                playerPos.position = pSpn2;

            }

        }
    }
}
