using UnityEngine;

public class BulletShooter : Shooter
{
    public float bulletDamage = 1f;

    public Transform firepointTransform;

    public GameObject bullet;

    public float fireForce;

    public AudioSource shootAudioSource;

    public AudioClip shootAudioClip;

    public void start()
    { 
        shootAudioSource = GetComponent<AudioSource>();
    }

    public override void Shoot()
    {
        if (shootAudioSource != null && shootAudioClip != null)
        {
            shootAudioSource.PlayOneShot(shootAudioClip);
        } 
        // Implement projectile shooting logic here

        GameObject bulletInstance = Instantiate(bullet, firepointTransform.position, firepointTransform.rotation);

        if (bulletInstance != null)
        { 
            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(firepointTransform.up * fireForce);
            }

            Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.damage = bulletDamage;
            }
        }
    }
}

