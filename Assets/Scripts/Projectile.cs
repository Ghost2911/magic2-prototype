using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float range;
    public GameObject particles;
    public float speed = 10f;

    public Transform owner;
    public float lifetime = 3f;

    public virtual void InitialSetup(Vector3 target, Transform owner, Vector3 offset, Vector2 swipeDir)
    {
        lifetime = 3f;
        transform.position += offset;
        this.owner = owner;
        transform.LookAt(target);
        StartCoroutine(Move());
    }

    protected IEnumerator Move()
    {
        while (true)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            lifetime -= Time.deltaTime;
            if (lifetime < 0)
                Destroy(this.gameObject);
            yield return null;
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.transform != owner)
        {
            if (collision.transform.CompareTag("Player"))
                collision.transform.GetComponent<Unit>()?.Damage(damage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject explossion = Instantiate(particles,transform.position,Quaternion.identity);
        Destroy(explossion, 0.4f);
    }
}
