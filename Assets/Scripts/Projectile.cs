using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forceAmount = 15.0f;
    public float destroyDelay = 3.0f; // Time delay before destroying the projectile

    private Vector3 shootDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(shootDirection * forceAmount, ForceMode.VelocityChange);

        // Destroy the projectile after a certain delay
        Destroy(gameObject, destroyDelay);
    }

    // Set the shooting direction
    public void SetShootDirection(Vector3 direction)
    {
        shootDirection = direction.normalized;
    }
}
