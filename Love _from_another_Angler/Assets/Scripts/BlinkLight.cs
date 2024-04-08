using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public GameObject enemyFollow;
    public GameObject player;
    public GameObject spawn;
    bool startFollow;
    public float followSpeed;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched the light! Following!");
            startFollow = true;
        }
    }
    
    void Update()
    {

        if (player != null && startFollow)
        {
            // Calculate the direction from this object to the player
            Vector3 direction = spawn.transform.position - enemyFollow.transform.position;

            // Calculate the distance between this object and the player
            float distance = direction.magnitude;

            // Check if the distance is greater than a small value to avoid jittering
            if (distance > 0.1f)
            {
                // Normalize the direction to get a unit vector
                direction /= distance;

                // Calculate the movement amount based on the follow speed and deltaTime
                float movement = followSpeed * Time.deltaTime;

                // Move this object towards the player with reduced velocity
                enemyFollow.transform.position += direction * movement;
            }
        }
    }
}
