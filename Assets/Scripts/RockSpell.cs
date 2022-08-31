using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpell : Projectile
{
    public override void InitialSetup(Vector3 target, Transform owner, Vector3 offset, Vector2 swipeDir)
    {
        lifetime = 3f;
        transform.position = target + Vector3.up*15f;
        this.owner = owner;
        transform.LookAt(target);
        StartCoroutine(Move());
    }
}
