using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public void OnCollection()
    {
        ScoreManager.Singleton.IncreaseCoinAmount();
        Destroy(gameObject);
    }
}