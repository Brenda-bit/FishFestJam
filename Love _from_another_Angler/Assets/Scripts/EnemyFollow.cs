using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject closed;
    public GameObject open;
    public GameObject spawn;
    bool startFollow;
    public float followSpeed;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Open"))
        {
            if (closed.activeSelf)
            {
                Debug.Log("Yeeah Killed U!");
            }
            else if (closed.activeSelf == false)
            {
                Debug.Log("Are u crazy? Follow!");
                startFollow = true;
            }
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Yeeah Killed U!");
        }
        if (other.CompareTag("Coral"))
        {
            startFollow = false;
            Debug.Log("Stop");
        }
    }
    void Update()
    {
        if(startFollow == false)
        {
            Vector3 direction = spawn.transform.position - transform.position;

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
                transform.position += direction * movement;
            }
        }
        if (player != null && startFollow)
        {
            // Calculate the direction from this object to the player
            Vector3 direction = player.transform.position - transform.position;

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
               transform.position += direction * movement;
            }
        }
    }
}
