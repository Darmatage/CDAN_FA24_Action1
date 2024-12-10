using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public GameHandler gameHandler;
    public Transform pSpawn;

    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    void Update()
    {
        if(pSpawn != null)
        {
            if(GameHandler.playerHealth <= 0)
            {
                Debug.Log("I am going back to the last spawn point");
                Vector3 pSpn2 = new Vector3(pSpawn.position.x, pSpawn.position.y, transform.position.z);
                gameObject.transform.position = pSpn2;
                ///GameHandler.playerHealth = 100;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            pSpawn = other.gameObject.transform;
            GameObject thisCheckpoint = other.gameObject;
            StopCoroutine(changeColor(thisCheckpoint));
            StartCoroutine(changeColor(thisCheckpoint));
        }
    }

    IEnumerator changeColor(GameObject thisCheckpoint)
    {
        Renderer checkRend = thisCheckpoint.GetComponentInChildren<Renderer>();
        checkRend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        checkRend.material.color = Color.white;
    }
}
