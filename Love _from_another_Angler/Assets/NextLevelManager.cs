using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelManager : MonoBehaviour
{
    public ParticleSystem particleSystem; // Referência ao sistema de partículas
    public Sprite newSprite; // Nova sprite a ser atribuída ao objeto
    public GameObject player; // Referência ao objeto do jogador

    private SpriteRenderer spriteRenderer; // Referência ao componente SpriteRenderer

    void Start()
    {
        // Obtém o componente SpriteRenderer do objeto
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Desativa o sistema de partículas no início
        if (particleSystem != null)
        {
            particleSystem.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou na trigger é o jogador (ou outro objeto específico)
        if (other.CompareTag("Player"))
        {
            // Ativa o sistema de partículas se houver um atribuído
            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            // Altera a sprite do objeto para a nova sprite atribuída
            if (spriteRenderer != null && newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }

            // Desativa o objeto do jogador
            if (player != null)
            {
                Destroy(player);
            }

            // Invoca a função para carregar a próxima cena após 3 segundos
            Invoke("LoadNextScene", 3f);
        }
    }

    void LoadNextScene()
    {
        // Obtém o índice da cena atual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carrega a próxima cena somando 1 ao índice atual
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
