using UnityEngine;

public class Shield : MonoBehaviour, ICollectable
{
    private Player player;

    private void Awake() => player = FindObjectOfType<Player>();

    public void OnCollection()
    {
        player.SetPlayerInvincible();
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
    }
}
