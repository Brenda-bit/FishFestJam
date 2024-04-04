using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFishScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject lightOff;
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput,0f) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space) && lightOff.activeSelf == false)
        {
            lightOff.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && lightOff.activeSelf == true) 
        {
            lightOff.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      
       Debug.Log("Player collided with the trigger object!");
    }
}
