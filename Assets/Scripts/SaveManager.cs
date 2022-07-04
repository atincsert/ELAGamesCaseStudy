using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private static SaveManager Singleton;

    private static string lastSceneIndex = "lastSceneIndex";
    private static string coinAmount = "coinAmount";

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else if (Singleton != null && Singleton != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator Start()
    {
        int savedSceneIndex = PlayerPrefs.GetInt(lastSceneIndex, 0);

        yield return LoadSceneAsync(savedSceneIndex);

        int savedCoinAmount = PlayerPrefs.GetInt(coinAmount, 0);
        ScoreManager.Singleton.FindCoinTextComponent();
        ScoreManager.Singleton.SetCoinAmount(savedCoinAmount);
    }

    private void SaveSceneIndex()
    {
        PlayerPrefs.SetInt(lastSceneIndex, SceneManager.GetActiveScene().buildIndex);
    }

    private void SaveCoinAmount()
    {
        PlayerPrefs.SetInt(coinAmount, ScoreManager.Singleton.GetCoinAmount());
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    // Called before quiting app
    private void OnApplicationQuit()
    {
        SaveSceneIndex();
        SaveCoinAmount();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            SaveSceneIndex();
            SaveCoinAmount();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause == true)
        {
            SaveSceneIndex();
            SaveCoinAmount();
        }
    }
}