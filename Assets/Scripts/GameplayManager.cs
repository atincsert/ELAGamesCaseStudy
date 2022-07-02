using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    private void Start() => Time.timeScale = 0;

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void NextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}