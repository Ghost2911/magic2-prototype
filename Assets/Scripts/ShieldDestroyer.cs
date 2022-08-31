using UnityEngine;

public class ShieldDestroyer : Projectile
{
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.transform != owner)
        {
            if (collision.transform.CompareTag("Player"))
                collision.transform.GetComponent<Unit>()?.ShieldDestroy();
            Destroy(gameObject);
        }
    }
}
