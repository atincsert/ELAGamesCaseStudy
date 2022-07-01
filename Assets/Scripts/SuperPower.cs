using UnityEngine;
using UnityEngine.UI;

public class SuperPower : MonoBehaviour
{
    [SerializeField] private Button superPowerButton;
    
    private Camera cam;
    private bool isAvailable = true;
    private void Awake() => cam = Camera.main;

    public void ActivateSuperPower()
    {
        if (isAvailable)
        {
            Ray ray = new Ray(cam.transform.position, -Vector3.right);
            RaycastHit[] hits = Physics.BoxCastAll(cam.transform.position, new Vector3(0, 38, 18), -Vector3.right);

            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.CompareTag("Obstacle"))
                    Destroy(hit.transform.gameObject);
            }
        }

        isAvailable = false;
        superPowerButton.enabled = false;
        superPowerButton.image.enabled = false;
    }
}
