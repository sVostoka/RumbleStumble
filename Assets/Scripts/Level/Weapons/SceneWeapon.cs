using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWeapon : MonoBehaviour
{
    [SerializeField] public GameObject weapon;
    [SerializeField] public GameObject bulletOrigin;
    [SerializeField] public ParticleSystem muzzleFlash;
}
