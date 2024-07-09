using System.Security.Policy;
using UnityEngine;
using UnityEngine.AI;

public class DashForward : MonoBehaviour
{
    private NavMeshAgent _agent;
    private HeroController _player;
    private EnemyController _enemy;

    private LayerMask _ignoreLayer;

    private Vector3 _targetPosition;
    private float _baseSpeed;

    private bool _isDash;

    private RaycastHit _raycastHit;

    public int Damage { get; set; }

    public float Distance { get; set; }

    private void Start()
    {
        _player = FindObjectOfType<HeroController>();
        _agent = GetComponent<NavMeshAgent>();
        _enemy = GetComponentInParent<EnemyController>();

        _ignoreLayer = _enemy.IgnoreLayer;
    }

    public void Dash()
    {
        if (Physics.Raycast(new(transform.position.x, transform.position.y + 5, transform.position.z), transform.forward, out _raycastHit, 500, _ignoreLayer))
        {
            if (Physics.Raycast(_raycastHit.point, Vector3.down, out _raycastHit, 20, _ignoreLayer))
            {
                Instantiate(Resources.Load<GameObject>("Prefabs/Test"), _raycastHit.point, Quaternion.identity);

                _targetPosition = _raycastHit.point;
                _isDash = true;
                _agent.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (_isDash)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, 50 * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, _targetPosition) < 0.5f)
        {
            _isDash = false;
            _agent.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HeroController>() && other.GetType() != typeof(CharacterController))
        {
            _player.Damage(Damage);
        }
    }
}
