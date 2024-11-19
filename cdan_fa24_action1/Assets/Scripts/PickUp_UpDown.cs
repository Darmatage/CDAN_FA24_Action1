using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_UpDown : MonoBehaviour
{

    private Vector3 startPos;

    public float speedS = 2.5f;
    public float distS = 0.5f;

    //parameters to randomize movement
    private float randBottom = 0.6f;
    private float randTop = 1f;

    private bool SinWaveMove = true;
    private bool randomizeSin = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        //randomize the distance
        if (randomizeSin == true)
        {
            speedS = (speedS * Random.Range(randBottom, randTop));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SinWaveMove == true)
        {
            transform.position = startPos + new Vector3(0.0f, (Mathf.Sin(Time.time * speedS) * distS), 0.0f);
        }
    }
}
