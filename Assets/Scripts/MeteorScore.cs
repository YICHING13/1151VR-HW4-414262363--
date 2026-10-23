
using UnityEngine;

public class MeteorScore : MonoBehaviour
{
    private Transform player;
    private bool scored = false;

    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
            player = playerObject.transform;
    }

    void Update()
    {
        if (player == null || scored) return;

        if (GameManager.Instance == null) return;
        if (GameManager.Instance.isGameOver) return;

        if (player.position.z > transform.position.z + 3f)
        {
            scored = true;
            GameManager.Instance.AddScore();

            Destroy(gameObject);
        }
    }
}
