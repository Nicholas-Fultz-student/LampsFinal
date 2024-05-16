using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public GameObject ThingToDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Destroy the wall upon collision with the projectile
            Destroy(ThingToDestroy);
        }
    }
}
