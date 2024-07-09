using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Explosion : MonoBehaviour
{
    private GameObject _sphere;
    private MeshRenderer _meshRenderer;
    private HeroController _player;
    private NavMeshAgent _agent;
    private EnemyController _enemy;

    private void Start()
    {
        _sphere = GetComponentInChildren<MeshRenderer>().gameObject;

        _meshRenderer = _sphere.GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;

        _player = FindObjectOfType<HeroController>();
        _agent = GetComponentInParent<NavMeshAgent>();

        _enemy = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HeroController>() && other.GetType() != typeof(CharacterController))
        {
            _agent.isStopped = true;
            _meshRenderer.enabled = true;
            StartCoroutine(StartExplosion());
        }
    }

    public IEnumerator StartExplosion()
    {
        while(_sphere.transform.localScale.x < 30)
        {
            float scaleValue = 10 * Time.deltaTime;

            _sphere.transform.localScale += new Vector3(scaleValue, scaleValue, scaleValue);

            yield return null;
        }

        if (GetComponent<Collider>().bounds.Contains(_player.transform.position))
        {
            _player.Damage(5000);
        }

        _enemy.Damage(5000);

        yield return null;
    }
}