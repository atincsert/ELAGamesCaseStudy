using UnityEngine;

public class MoveMissile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;

    private void Update() => transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
}
