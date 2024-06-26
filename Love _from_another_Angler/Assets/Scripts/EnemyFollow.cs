using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Debug.Log("Are u crazy? Follow!");
            startFollow = true;
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Yeeah Killed U!");
            FindObjectOfType<AudioManager>().Play("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            float distance = direction.magnitude;
            if (distance > 0.1f)
            {
                direction /= distance;

                float movement = followSpeed * Time.deltaTime;
                transform.position += direction * movement;
            }
        }
        if (player != null && startFollow)
        {
            Vector3 direction = player.transform.position - transform.position;
            float distance = direction.magnitude;
            if (distance > 0.1f)
            {
                direction /= distance;
                float movement = followSpeed * Time.deltaTime;

               transform.position += direction * movement;
            }
        }
    }
}
