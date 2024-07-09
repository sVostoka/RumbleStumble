using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClotBullet : MonoBehaviour
{
    private RaycastHit _hit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Terrain>() || other.name == "DesertTemple_Platform_01")
        {
            if(Physics.Raycast(transform.position, Vector3.down, out _hit, 5))
            {
                GameObject puddle = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Attack/Clot/ClotPuddle"), _hit.point, Quaternion.identity);

                Destroy(puddle, 10f);
            }
            Destroy(gameObject);
        }
    }
}
