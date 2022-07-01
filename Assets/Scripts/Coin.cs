using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public void OnCollection()
    {
        //TODO: +1 to coins in the UI when called 
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
    }
}
