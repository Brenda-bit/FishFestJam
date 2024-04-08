using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private string goToLevel;
    [SerializeField] private GameObject infoPanel;

    public void PressedButton()
    {
        SceneManager.LoadScene(goToLevel);
    }

    public void OpenInfoButton()
    {
        if(infoPanel != null)
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
        if(infoPanel != null)
        {
            infoPanel.SetActive(false); // Desativa o painel de informações
        }
        else
        {
            Debug.LogWarning("Info Panel não está atribuído!");
        }
    }


}
