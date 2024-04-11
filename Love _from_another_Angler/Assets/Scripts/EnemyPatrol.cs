using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject player;
    public GameObject open;
    public GameObject point1;
    public GameObject point2;
    bool startFollow;
    public float followSpeed;
    bool movingToFirst;

    void Start()
    {
    }

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
            movingToFirst = true;
            Debug.Log("Stop");
        }
    }
    void Update()
    {

        if (startFollow == false)
        {
            Transform targetPoint = movingToFirst ? point1.transform : point2.transform;
            Vector3 direction = targetPoint.position - transform.position;

            float distance = direction.magnitude;
            if (distance > 0.1f)
            {
                direction /= distance;
                float movement = followSpeed * Time.deltaTime;
                transform.position += direction * movement;
            }
            else
            {
                movingToFirst = !movingToFirst;
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
