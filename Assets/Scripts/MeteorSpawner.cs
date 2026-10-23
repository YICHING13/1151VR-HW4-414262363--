
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public Transform player;

    public float spawnInterval = 2f;
    public float spawnDistance = 80f;

    public float horizontalRange = 12f;
    public float minHeight = 5f;
    public float maxHeight = 18f;

    private float timer;

    void Update()
    {
        if (player == null || meteorPrefab == null)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMeteor();
            timer = 0f;
        }
    }

    void SpawnMeteor()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-horizontalRange, horizontalRange),
            Random.Range(minHeight, maxHeight),
            player.position.z + spawnDistance
        );

        Instantiate(meteorPrefab, spawnPosition, Random.rotation);
    }
}
