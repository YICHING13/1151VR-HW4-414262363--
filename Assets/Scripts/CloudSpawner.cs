
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public Transform player;

    public float spawnInterval = 1.5f;
    public float spawnDistance = 100f;
    public float sideDistance = 18f;
    public float cloudHeight = -5f;
    public float destroyDistance = 40f;

    private float timer;

    void Update()
    {
        if (player == null || cloudPrefab == null)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnCloud();
        }
    }

    void SpawnCloud()
    {
        float side = Random.value < 0.5f ? -1f : 1f;

        Vector3 position = new Vector3(
            player.position.x + side * Random.Range(10f, sideDistance),
            cloudHeight + Random.Range(-2f, 2f),
            player.position.z + spawnDistance
        );

        GameObject cloud = Instantiate(
            cloudPrefab,
            position,
            Quaternion.identity
        );

        CloudCleanup cleanup = cloud.AddComponent<CloudCleanup>();
        cleanup.player = player;
        cleanup.destroyDistance = destroyDistance;
    }
}

public class CloudCleanup : MonoBehaviour
{
    public Transform player;
    public float destroyDistance = 40f;

    void Update()
    {
        if (player != null &&
            transform.position.z < player.position.z - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
