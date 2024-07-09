using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static Enums;

public class EnemiesGenerator : MonoBehaviour
{
    System.Random rnd = new();

    private float _minX;
    private float _maxX;

    private float _minZ;
    private float _maxZ;

    private List<EnemyAttack> _enemyAttacks;

    private List<Enemy> _enemies;
    private int _enemiesSpawnCount = 3;

    private int _enemiesLivingCount;

    public int EnemiesLivingCount
    {
        get => _enemiesLivingCount;
        set
        {
            _enemiesLivingCount = value;

            if(_enemiesLivingCount == 0)
            {
                FindObjectOfType<TriggerOpenDoor>().openDoor = true;
            }
        }
    }

    private float _xOffset = 5.0f;
    private float _zOffset = 5.0f;

    private void Awake()
    {
        GetEnemyPrefabs();
        GetEnemyAttacks();
    }

    public void Generate(float minX, float maxX, float minZ, float maxZ)
    {
        InitParams(minX, maxX, minZ, maxZ);

        ClearAllEnemies();
        Spawn();

        _enemiesLivingCount = _enemiesSpawnCount;
    }

    private void InitParams(float minX, float maxX, float minZ, float maxZ)
    {
        _minX = minX + _xOffset;
        _maxX = maxX - _xOffset;

        _minZ = minZ - _zOffset;
        _maxZ = maxZ;
    }

    private void GetEnemyPrefabs()
    {
        int preloadCount = Constants.EnemiesGenerator.PRELOADENEMYCOUNT;

        _enemies = new()
        {
            new("Prefabs/Enemies/Enemy1", new(delegate { return Preload("Prefabs/Enemies/Enemy1"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Enemies/Enemy2", new(delegate { return Preload("Prefabs/Enemies/Enemy2"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Enemies/Enemy3", new(delegate { return Preload("Prefabs/Enemies/Enemy3"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Enemies/Enemy4", new(delegate { return Preload("Prefabs/Enemies/Enemy4"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Enemies/Enemy5", new(delegate { return Preload("Prefabs/Enemies/Enemy5"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Enemies/Enemy6", new(delegate { return Preload("Prefabs/Enemies/Enemy6"); }, GetAction, ReturnAction, preloadCount)),
        };
    }

    private void GetEnemyAttacks()
    {
        _enemyAttacks = new()
        {
            new(AttackPattern.DamageArea, 3, 0, 3, 10),
            new(AttackPattern.DashForward, 5, 0, 10, 30),
            new(AttackPattern.Explosion, 3, 0, 10, 100),
            new(AttackPattern.Clot, 10, 0.5f, 10, 10),
            new(AttackPattern.Burst, 10, 0.5f, 10, 10),
            new(AttackPattern.Attraction, 10, 10, 50, 10),
        };
    }

    private void Spawn()
    {
        var distance = (Math.Abs(_minX) + Math.Abs(_maxX)) / _enemiesSpawnCount;

        for(int i = 0; i < _enemiesSpawnCount; i++)
        {
            var index = rnd.Next(0, _enemies.Count);

            Vector3 randomPosition = new(CalculateFloatValue(_minX + (distance * i), _minX + (distance * (i + 1)) - _xOffset), 5, _minZ);

            GameObject gameObject = _enemies[index].pool.GetElement();
            gameObject.GetComponent<NavMeshAgent>().Warp(randomPosition);

            gameObject.GetComponent<EnemyController>().BaseHp = 100;
            gameObject.GetComponent<EnemyController>().Resurrected();

            GetTypeAttack(gameObject.GetComponent<EnemyController>());
        }
    }

    private void GetTypeAttack(EnemyController enemy)
    {
        EnemyAttack enemyAttack = _enemyAttacks[rnd.Next(0, _enemyAttacks.Count)];

        enemy.SettingAttack = enemyAttack;
    }

    private float CalculateFloatValue(float left, float right)
    {
        return (float)(rnd.NextDouble() * (right - left) + left);
    }

    public void ClearAllEnemies()
    {
        foreach (var enemy in _enemies)
        {
            enemy.pool.ReturnAll();
        }
    }

    public GameObject Preload(string path) => Instantiate(Resources.Load(path) as GameObject, transform);
    public void GetAction(GameObject gameObject) 
    {
        gameObject.SetActive(true);
    }

    public void ReturnAction(GameObject gameObject) 
    {
        gameObject.SetActive(false);
    }
}