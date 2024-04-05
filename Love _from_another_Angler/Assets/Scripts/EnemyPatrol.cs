using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject player;
    public GameObject open;
    public GameObject point1;
    public GameObject point2;
    bool startFollow;
    public float followSpeed;
    bool movingToFirst;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Open"))
        {
            Debug.Log("Are u crazy? Follow!");
            startFollow = true;
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Yeeah Killed U!");
        }
        if (other.CompareTag("Coral"))
        {
            startFollow = false;
            movingToFirst = true;
            Debug.Log("Stop");
        }
    }
    void Update()
    {
        if (startFollow == false)
        {
            Transform targetPoint = movingToFirst ? point1.transform : point2.transform;

            // Calculate the direction towards the target point
            Vector3 direction = targetPoint.position - transform.position;

            // Calculate the distance between this object and the target point
            float distance = direction.magnitude;

            // Check if the distance is greater than a small value to avoid jittering
            if (distance > 0.1f)
            {
                // Normalize the direction to get a unit vector
                direction /= distance;

                // Calculate the movement amount based on the patrol speed and deltaTime
                float movement = followSpeed * Time.deltaTime;

                // Move this object towards the target point
                transform.position += direction * movement;
            }
            else
            {
                // If reached the target point, switch direction
                movingToFirst = !movingToFirst;
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
