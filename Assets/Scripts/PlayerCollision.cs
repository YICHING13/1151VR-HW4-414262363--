
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meteor"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
