using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFishScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject lightOff;
    private SpriteRenderer spriteRenderer;
    private float rotationSpeed = 1f; // Velocidade de rotação ajustável
    private float rotationTimer = 0f; // Timer para controlar a rotação
    private float targetRotation = 0.6f; // Alvo de rotação (1 para 1 grau, -1 para -1 grau)

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);

        // Atualiza o timer de rotação
        rotationTimer += Time.deltaTime;

        // Interpolação linear entre -1 e 1 com base no tempo e na velocidade de rotação
        float angle = Mathf.Lerp(-3f, 3f, Mathf.PingPong(rotationTimer * rotationSpeed, 1f));

        // Define a rotação Z do objeto
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);

        if (Input.GetKeyDown(KeyCode.Space) && !lightOff.activeSelf)
        {
            lightOff.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && lightOff.activeSelf)
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
