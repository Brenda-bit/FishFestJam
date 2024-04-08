using UnityEngine;
using Cinemachine;

public class FollowMate : MonoBehaviour
{
    public GameObject mate; // Objeto que a câmera seguirá caso não haja um objeto com a tag "Player"
    public CinemachineVirtualCamera virtualCamera; // Referência à sua Cinemachine Virtual Camera

    void Update()
    {
        // Verifica se existe um objeto com a tag "Player" na hierarquia
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Se não houver um objeto com a tag "Player", define o objeto "Mate" como o objeto a ser seguido pela câmera
        if (playerObject == null)
        {
            if (virtualCamera != null)
            {
                // Define o objeto "Mate" como o novo objeto a ser seguido pela câmera
                virtualCamera.Follow = mate.transform;
            }
            else
            {
                Debug.LogWarning("Virtual Camera não está atribuída!");
            }
        }
    }
}
