using UnityEngine;

public abstract class Death : MonoBehaviour
{
    // Abstract method to be implemented by derived classes for death behavior
    public abstract void Die();

    protected void TriggerExplosionEffect(GameObject explosionEffectPrefab)
    {
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
