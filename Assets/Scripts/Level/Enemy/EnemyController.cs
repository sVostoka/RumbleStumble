using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.Processors;
using static Enums;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private LayerMask _ignoreLayer;
    public LayerMask IgnoreLayer
    {
        get => _ignoreLayer;
    }

    [SerializeField] private float _baseHP;

    private bool _isDead = false;

    private NavMeshAgent _navMeshAgent;
    private HeroController _player;

    [Header ("Blood")]
    [SerializeField] private float _timeBloodLife;
    [SerializeField] private ParticleSystem _bloodParticle;

    private bool _alreadyAttacked;
    private bool _playerInAttackRange;
    private bool _playerInLineOfCheck;

    private EnemyAttack _settingAttack;
    public EnemyAttack SettingAttack 
    { 
        get => _settingAttack;
        set
        {
            _settingAttack = value;
            Preparation();
        } 
    }

    #region - Dead -
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private List<Collider> _colliders;
    [SerializeField] private GameObject _damageArea;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private Animator _animator;
    #endregion

    public float BaseHp
    {
        get => _baseHP;
        set 
        {
            _baseHP = value;
            
            if(_baseHP <= 0 && !_isDead)
            {
                Dead();
            }
        }
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<HeroController>();
    }

    void Update()
    {
        ChasePlayer();

        if (Physics.CheckSphere(transform.position, SettingAttack.AttackRange, _whatIsPlayer))
        {
            RaycastHit hit;
            var rayDirection = _player.transform.position - transform.position;
            if (Physics.Raycast(transform.position, rayDirection, out hit))
            {
                if (hit.collider.transform.GetComponent<HeroController>())
                {
                    AttackPlayer();
                }
            }
        }            
    }

    private void ChasePlayer()
    {
        _navMeshAgent.SetDestination(_player.transform.position);
    }

    private void AttackPlayer()
    {
        _navMeshAgent.SetDestination(transform.position);

        if (!_alreadyAttacked)
        {
            switch (SettingAttack.AttackPattern)
            {
                case AttackPattern.DashForward: DashForward(); break;
                case AttackPattern.Clot: Clot(); break;
                case AttackPattern.Burst: Burst(); break;
                case AttackPattern.Attraction: Attraction(); break;
            }

            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), SettingAttack.TimeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }

    #region PatternAttack

    private void Preparation()
    {
        switch (SettingAttack.AttackPattern)
        {
            case AttackPattern.DamageArea:
                _navMeshAgent.stoppingDistance = SettingAttack.AttackRange;
                DamageAreaPreparation(); 
                break;
            case AttackPattern.DashForward:
                _navMeshAgent.stoppingDistance = SettingAttack.AttackRange;
                DashForwardPreparation(); 
                break;
            case AttackPattern.Explosion:
                _navMeshAgent.stoppingDistance = SettingAttack.AttackRange;
                ExplosionPreparation(); 
                break;
        }
    }

    public void DamageAreaPreparation()
    {
        GameObject damageArea = transform.Find("DamageArea").gameObject;
        damageArea.SetActive(true);
        damageArea.GetComponentInChildren<DamageArea>().Damage = SettingAttack.BaseDamage;
        damageArea.GetComponentInChildren<DamageArea>().TimeBetweenAttacks = SettingAttack.TimeBetweenAttacks;
    }

    public void DashForwardPreparation()
    {
        this.AddComponent<DashForward>();
        GetComponent<DashForward>().Damage = SettingAttack.BaseDamage;
        GetComponent<DashForward>().Distance = SettingAttack.AttackRange;
    }

    public void DashForward()
    {
        GetComponent<DashForward>().Dash();
    }

    public void ExplosionPreparation()
    {
        GameObject damageArea = transform.Find("Explosion").gameObject;
        damageArea.SetActive(true);
    }

    public void Clot()
    {
        StartCoroutine(ClotCoroutine());
    }

    private IEnumerator ClotCoroutine()
    {
        for(int i = 0; i < 3; i++)
        {
            Vector3 lookPos = _player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(lookPos);
            Vector3 shootPosition = GameObject.Find("ShootPoint").transform.position;

            Rigidbody rb = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Attack/Clot/ClotBullet"), shootPosition, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 15f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            yield return new WaitForSeconds(SettingAttack.TimeBetweenBullet);
        }

        yield return null;
    }

    public void Burst()
    {
        StartCoroutine(BurstCoroutine());
    }

    private IEnumerator BurstCoroutine()
    {
        for (int i = 0; i < 15; i++)
        {
            Vector3 lookPos = _player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(lookPos);
            Vector3 shootPosition = GameObject.Find("ShootPoint").transform.position;

            Rigidbody rb = Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Attack/Burst/BurstBullet"), shootPosition, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
            rb.AddForce(transform.up * 0f, ForceMode.Impulse);

            yield return new WaitForSeconds(SettingAttack.TimeBetweenBullet);
        }

        yield return null;
    }

    public void Attraction()
    {
        StartCoroutine(AttractionCoroutine());
    }

    private IEnumerator AttractionCoroutine()
    {
        _player.MoveToEnemy(transform.position);
        _player.Damage(40);

        _player.StopControll();

        yield return new WaitForSeconds(5);

        _player.ResumeControll();

        yield return null;
    }

    #endregion

    #region - Damage -
    public void Damage(int damage, RaycastHit _raycastHit = new())
    {
        BaseHp -= damage;
        _bloodParticle.transform.position = _raycastHit.point;
        _bloodParticle.transform.localRotation = Quaternion.LookRotation(_raycastHit.normal);
        _bloodParticle.Play();
    }

    private void Dead()
    {
        _isDead = true;

        _animator.enabled = false;
        _navMeshAgent.enabled = false;
        foreach(var collider in _colliders)
        {
            collider.enabled = true;
        }
        _rigidbody.useGravity = true;
        _damageArea.SetActive(false);
        _explosion.SetActive(false);
        enabled = false;
        Destroy(GetComponent<DashForward>());

        FindObjectOfType<EnemiesGenerator>().EnemiesLivingCount -= 1;
    }

    public void Resurrected()
    {
        _isDead = false;

        _animator.enabled = true;
        _navMeshAgent.enabled = true;
        foreach (var collider in _colliders)
        {
            collider.enabled = false;
        }
        _rigidbody.useGravity = false;
        enabled = true;
    }

    #endregion

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, SettingAttack.AttackRange);
    }
}
