using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public GameObject light;
   
    void Start()
    {
        // Start the coroutine to toggle the light
        StartCoroutine(ToggleLight());
    }

    IEnumerator ToggleLight()
    {
        while (true)
        {
            // Enable the light
            light.active = true;
            yield return new WaitForSeconds(5);

            // Disable the light
            light.active = false;
            yield return new WaitForSeconds(5);
        }
    }
}
