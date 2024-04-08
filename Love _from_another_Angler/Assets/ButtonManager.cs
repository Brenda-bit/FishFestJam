using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private string nextLevel; // Próxima fase
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private List<GameObject> objectsToDisable; // Lista dos objetos a serem desativados
    [SerializeField] private Image imageToShrink; // Referência à imagem a ser reduzida
    [SerializeField] private float shrinkSpeed; // Velocidade de redução da imagem

    private Coroutine shrinkCoroutine; // Referência para a coroutine de redução da imagem

    public void PressedButton()
    {
        // Verifica se a lista de objetos não está vazia
        if (objectsToDisable != null)
        {
            // Percorre todos os objetos na lista e define suas posições para uma posição distante
            foreach (GameObject obj in objectsToDisable)
            {
                if (obj != null)
                {
                    obj.transform.position = new Vector3(10000f, 10000f, 10000f); // Move o objeto para uma posição distante
                }
                else
                {
                    Debug.LogWarning("Um objeto na lista não está atribuído!");
                }
            }
        }
        else
        {
            Debug.LogWarning("Nenhum objeto para desativar foi atribuído!");
        }

        // Inicia a redução da imagem
        if (imageToShrink != null)
        {
            if (shrinkCoroutine != null)
            {
                StopCoroutine(shrinkCoroutine); // Se já estiver encolhendo, interrompe a coroutine anterior
            }
            shrinkCoroutine = StartCoroutine(ShrinkImage());
        }
        else
        {
            Debug.LogWarning("Nenhuma imagem para reduzir foi atribuída!");
        }
    }

    public void OpenInfoButton()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true); // Ativa o painel de informações
        }
        else
        {
            Debug.LogWarning("Info Panel não está atribuído!");
        }
    }

    public void CloseInfoButton()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false); // Desativa o painel de informações
        }
        else
        {
            Debug.LogWarning("Info Panel não está atribuído!");
        }
    }

    IEnumerator ShrinkImage()
    {
        // Loop até a altura da imagem atingir 0
        while (imageToShrink.rectTransform.sizeDelta.y > 0)
        {
            // Reduz a altura da imagem
            imageToShrink.rectTransform.sizeDelta -= new Vector2(0f, shrinkSpeed * Time.deltaTime);

            // Espera até o próximo frame
            yield return null;
        }

        // Verifica se a altura da imagem é menor ou igual a 0
        if (imageToShrink.rectTransform.sizeDelta.y <= 0)
        {
            Invoke ("LoadNextScene", 0.5f);
        }
    }

    public void LoadNextScene()
    {
        // Avança para a próxima fase
        SceneManager.LoadScene(nextLevel);
    }
}