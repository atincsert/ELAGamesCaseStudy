using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Button tapToPlayButton;
    private void Start() => Time.timeScale = 0;

    // Calling from unity event button
    public void PlayGame()
    {
        Time.timeScale = 1;
        tapToPlayButton.gameObject.SetActive(false);
    }

    // Calling from unity event button

    //public void Restart()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    //public void NextLevel()
    //{
    //    int nextSceneIndex;
    //    int totalSceneCount = SceneManager.sceneCountInBuildSettings;
    //    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    //    nextSceneIndex = currentSceneIndex + 1 < totalSceneCount ? currentSceneIndex + 1 : 0;
    //    SceneManager.LoadScene(nextSceneIndex);
    //}
}