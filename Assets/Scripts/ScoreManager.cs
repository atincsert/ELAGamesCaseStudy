using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Singleton;
    private int coinAmount = 0;

    [SerializeField] private TextMeshProUGUI coinText;

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

    public void IncreaseCoinAmount()
    {
        coinAmount += 1;
        UpdateCoinText(coinAmount);
    }

    public int GetCoinAmount()
    {
        return coinAmount; 
    }

    public void SetCoinAmount(int _amount)
    {
        coinAmount = _amount;
        UpdateCoinText(coinAmount);
    }

    public void FindCoinTextComponent()
    {
        coinText = FindObjectOfType<Canvas>().transform.GetChild(4).GetComponent<TextMeshProUGUI>();
    }

    private void UpdateCoinText(int _coinAmount)
    {
        Debug.Log("Passed coin amount is " + _coinAmount);
        coinText.SetText("x " + _coinAmount.ToString());
    }
}