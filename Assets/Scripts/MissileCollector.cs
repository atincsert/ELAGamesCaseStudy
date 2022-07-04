using UnityEngine;

public class MissileCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MoveMissile>(out MoveMissile missile))
        {
            Destroy(other.gameObject);
        }
    }
}