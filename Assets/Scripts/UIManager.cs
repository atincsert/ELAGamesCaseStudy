using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button superPowerBttn, tapToStartBttn, retryBttn, nextLevelBttn;

    private void Start()
    {
        superPowerBttn.onClick.AddListener(() => FindObjectOfType<SuperPower>().ActivateSuperPower());
        tapToStartBttn.onClick.AddListener(() => FindObjectOfType<GameplayManager>().PlayGame());
        retryBttn.onClick.AddListener(() => FindObjectOfType<SceneMan>().PlayCurrentScene());
        nextLevelBttn.onClick.AddListener(() => FindObjectOfType<SceneMan>().PlayNextScene());
    }
}