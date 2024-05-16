using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform playerCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        if (playerCamera != null)
        {
            // Calculate the direction the player is looking
            Vector3 shootDirection = playerCamera.forward;

            // Set the shooting direction for the projectile
            Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.SetShootDirection(shootDirection);
            }
            else
            {
                Debug.LogError("Projectile script not found on the instantiated object.");
            }
        }
        else
        {
            Debug.LogError("Player camera reference not set in the Cannon script.");
        }
    }
}
