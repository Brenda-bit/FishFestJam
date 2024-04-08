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
            Vector3 direction = spawn.transform.position - enemyFollow.transform.position;

            float distance = direction.magnitude;

            if (distance > 0.1f)
            {
               
                direction /= distance;
                float movement = followSpeed * Time.deltaTime;
                enemyFollow.transform.position += direction * movement;
            }
        }
    }
}
