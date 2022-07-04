using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        winScreen.SetActive(true);
    }
}
