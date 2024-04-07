using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private string goToLevel;

    public void PressedButton()
    {
        SceneManager.LoadScene(goToLevel);
    }


}
