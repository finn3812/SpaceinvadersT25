using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();

        if (player != null)
            player.TakeHit();
    }
}