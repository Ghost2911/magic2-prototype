using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private bool invulnerability = false;

    [SerializeField]
    private GameObject shield;
    [HideInInspector]
    public UnityEvent OnDamage;
    private void Start()
    {
        shield.SetActive(false);
    }

    public void Damage(int damage)
    {
        if (damage != 0 && !invulnerability)
        {
            Debug.Log($"{transform.name} - damage: {damage}");
            OnDamage.Invoke();
        }
    }

    public void ShieldActivate()
    {
        StartCoroutine(Invulnerability());
    }

    IEnumerator Invulnerability()
    {
        if (!invulnerability)
        {
            invulnerability = true;
            shield.SetActive(invulnerability);
            yield return new WaitForSeconds(5f);
            invulnerability = false;
            shield.SetActive(invulnerability);
        }
    }

    public void ShieldDestroy()
    {
        StopCoroutine(Invulnerability());
        invulnerability = false;
        shield.SetActive(invulnerability);
    }
}
