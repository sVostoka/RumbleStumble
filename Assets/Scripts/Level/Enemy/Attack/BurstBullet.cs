using UnityEngine;

public class BurstBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponentInParent<EnemyController>() && !other.GetComponent<EnemyController>())
        {
            if (other.GetComponent<HeroController>())
            {
                other.GetComponent<HeroController>().Damage(20);
            }

            Destroy(gameObject);
        }
    }
}
