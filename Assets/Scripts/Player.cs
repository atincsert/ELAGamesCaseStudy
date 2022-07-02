using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float downwardVelocity = 500f, upwardVelocity = 1000f;
    [SerializeField] private float forwardVelocity = 5f;
    [SerializeField] private float invincibilityDuration = 3f;

    private Rigidbody rb;
    private bool isInvincible;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        VerticalMovement();
        HorizontalMovement();
    }

    private bool IsMouseOverUI() => UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

    private void VerticalMovement()
    {
        bool isPressed = Input.GetMouseButton(0);
        if (isPressed && !IsMouseOverUI())
            rb.AddForce(Vector3.up * upwardVelocity * Time.fixedDeltaTime, ForceMode.Force);
        else
            rb.AddForce(Vector3.down * downwardVelocity * Time.fixedDeltaTime);
    }

    private void HorizontalMovement() => rb.velocity = new Vector3
        (0, rb.velocity.y, Mathf.Clamp(rb.velocity.z, forwardVelocity, forwardVelocity));


    private void CollisionWithObstacles(Collision collision)
    {
        if (isInvincible == true) return;
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            // TODO: Show Game Over UI and Retry button
        }
    }

    public void SetPlayerInvincible() => StartCoroutine(BecomeInvincibleForCertainDuration());

    private IEnumerator BecomeInvincibleForCertainDuration()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
    private void OnCollisionEnter(Collision collision) => CollisionWithObstacles(collision);
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectable collectable))
        {
            collectable.OnCollection();
        }
    }
}
