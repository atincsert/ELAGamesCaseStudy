using UnityEngine;
using Cinemachine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 floor, ceiling;
    [SerializeField] private Transform missilePrefab;
    [SerializeField] private float minTimeToSpawn = 3f, maxTimeToSpawn = 6f;

    private float zDistance;
    private CinemachineVirtualCamera cam;
    private float nextTimeStamp;

    private void Awake()
    {
        cam = FindObjectOfType<CinemachineVirtualCamera>();
        zDistance = Mathf.Abs(cam.transform.position.z - transform.position.z);
        Debug.Log(zDistance);
    }
    private void Start() => nextTimeStamp = Random.Range(minTimeToSpawn, maxTimeToSpawn);

    private void Update()
    {
        KeepingDistance();

        nextTimeStamp -= Time.deltaTime;
        if (nextTimeStamp <= 0f)
        {
            SpawnMissile();
            nextTimeStamp = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        }
    }

    private void KeepingDistance()
    {
        transform.position = new Vector3
(transform.position.x, transform.position.y, cam.transform.position.z + zDistance);
    }

    private Vector3 AssignRandomHeight()
    {
        var randomHeightValue = Random.Range(floor.y, ceiling.y);
        var randomPosition = new Vector3(transform.position.x, randomHeightValue, transform.position.z);
        return randomPosition;
    }

    private void SpawnMissile()
    {
        Vector3 returnedValue = AssignRandomHeight();
        var instanceObject = Instantiate(missilePrefab);
        instanceObject.transform.position = returnedValue;
    }
}
