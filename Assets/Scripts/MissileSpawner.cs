using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 floor, ceiling;
    [SerializeField] private Transform missilePrefab;
    [SerializeField] private float minTimeToSpawn = 3f, maxTimeToSpawn = 6f;

    private float zDistance;
    private Camera cam;
    private float nextTimeStamp;

    private void Awake()
    {
        cam = Camera.main;
        zDistance = Mathf.Abs(cam.transform.position.z - transform.position.z);
    }
    private void Start()
    {
        nextTimeStamp = Random.Range(minTimeToSpawn, maxTimeToSpawn);
    }

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
        Debug.Log(transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z + zDistance);    
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(floor, 0.2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(ceiling, 0.2f);
    }
}
