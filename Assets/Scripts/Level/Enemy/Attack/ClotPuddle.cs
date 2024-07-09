using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClotPuddle : MonoBehaviour
{
    private HeroController _player;
    private IEnumerator _coroutine;

    private void Start()
    {
        _player = FindObjectOfType<HeroController>();
        _coroutine = GiveDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HeroController>())
        {
            StartCoroutine(_coroutine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<HeroController>())
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator GiveDamage()
    {
        while (true)
        {
            _player.Damage(5);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
