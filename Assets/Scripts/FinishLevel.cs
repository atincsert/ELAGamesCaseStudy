using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private float sceneCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            if (sceneCount > 2) SceneManager.LoadScene(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
