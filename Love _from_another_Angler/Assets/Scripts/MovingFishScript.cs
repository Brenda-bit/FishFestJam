using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFishScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject lightOff;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mate"))
        {
            Debug.Log("Mated");
        }
    }
}
