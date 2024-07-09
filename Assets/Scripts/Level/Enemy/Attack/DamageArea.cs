using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private HeroController _player;
    private MeshRenderer _meshRenderer;

    public int Damage { get; set;}

    public float TimeBetweenAttacks { get; set; }

    private IEnumerator _coroutine;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;

        _player = FindObjectOfType<HeroController>();

        _coroutine = GiveDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HeroController>() && other.GetType() != typeof(CharacterController))
        {
            StartCoroutine(_coroutine);
            _meshRenderer.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<HeroController>() && other.GetType() != typeof(CharacterController))
        {
            StopCoroutine(_coroutine);
            _meshRenderer.enabled = false;
        }
    }

    private IEnumerator GiveDamage()
    {
        while(true)
        {
            _player.Damage(Damage);
            yield return new WaitForSeconds(TimeBetweenAttacks);
        }
    }
}
