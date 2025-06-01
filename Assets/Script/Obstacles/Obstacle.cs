using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    [SerializeField]
    private bool isInstaKill;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D otherObject)
    {
        
        Health healthComponent = otherObject.gameObject.GetComponent<Health>();

        if (healthComponent != null)
        {
            if (isInstaKill)
            {
                healthComponent.InstaKill(); // Instantly kill the object if isInstaKill is true
            }
            else
            {
                healthComponent.TakeDamage(damageAmount);
            }

            Health health = GetComponent<Health>();

            if (health != null)
            {
                health.InstaKill();
            }


            
            
        }
    }
}
