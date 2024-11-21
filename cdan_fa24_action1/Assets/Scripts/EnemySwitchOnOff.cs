using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitchOnOff : MonoBehaviour

{

    public bool isActive = false; // Toggle state

    public float normalSpeed = 2f; // Default movement speed

    public float activeSpeed = 0f; // Enemy deactivates



    void Update()

    {

        // Example trigger: Press 'T' to toggle state

        if (Input.GetKeyDown(KeyCode.T)) 

        {

            ToggleState();

        }



        // Movement based on state

        float movementSpeed = isActive ? activeSpeed : normalSpeed;

        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

    }



    void ToggleState()

    {

        isActive = !isActive;

        Debug.Log("Enemy state toggled: " + isActive);

    }

}