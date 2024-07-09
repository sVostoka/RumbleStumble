using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private FadeController _fadeController;

    private HeroController _player;

    private RoomGenerator _roomGenerator;
    private TerrainGenerator _terrainGenerator = new();
    private EnvironmentGenerator _environmentGenerator;
    private EnemiesGenerator _enemiesGenerator;

    private SurfacesController _surfacesController;
    private CheckCorrectEnvironment _checkCorrect;

    private void Awake()
    {
        _fadeController = FindObjectOfType<FadeController>();

        _player = FindObjectOfType<HeroController>();

        _roomGenerator = GetComponentInChildren<RoomGenerator>();
        _terrainGenerator = GetComponentInChildren<TerrainGenerator>();
        _environmentGenerator = GetComponentInChildren<EnvironmentGenerator>();
        _enemiesGenerator = FindObjectOfType<EnemiesGenerator>();

        _surfacesController = GetComponent<SurfacesController>();
        _checkCorrect = FindObjectOfType<CheckCorrectEnvironment>();
    }

    private void Start()
    {
        GenerateLevel();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            GenerateLevel();
        }
    }

    public void GenerateLevel()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        _enemiesGenerator.ClearAllEnemies();

        _player.StopControll();

        yield return _fadeController.FadeCorutine();

        _player.MoveToSpawnPoint();

        var (minX, maxX, minZ, maxZ) = _roomGenerator.Generate();
        _terrainGenerator.Generate();
        _environmentGenerator.Generate(minX, maxX, minZ, maxZ);

        yield return StartCoroutine(_surfacesController.UpdateMesh());

        if (!_checkCorrect.Check(minX, maxX, minZ, maxZ))
        {
            GenerateLevel();
        }
        else
        {
            _enemiesGenerator.Generate(minX, maxX, minZ, maxZ);

            _fadeController.Brighten();
            _player.ResumeControll();
        }
    }
}