using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    System.Random rnd = new();

    [SerializeField] private float _minX = -10.0f;
    [SerializeField] private float _maxX = 20.0f;

    [SerializeField] private float _minZ = -10.0f;
    [SerializeField] private float _maxZ = 25.0f;

    private float _sizeTile;

    private List<PropForTile> _propsLarge;
    private List<PropForTile> _propsMedium;
    private List<PropForTile> _propsSmall;

    private List<EnvironmentPrefabForTile> _envPrefabs;
    private EnvironmentPrefabForTile[,] _room;

    private void Awake()
    {
        _sizeTile = Constants.EnvironmentGenerator.SIZETILE;

        GetEnvPrefabs();
        GetPropsPrefabs();
    }

    public void Generate(float? minX, float? maxX, float? minZ, float? maxZ)
    {
        InitParams(minX, maxX, minZ, maxZ);

        CleanEnvironment();
        GeneratePossition();
        SpawnEnvironment();
    }

    private void InitParams(float? minX, float? maxX, float? minZ, float? maxZ)
    {
        _minX = minX ?? _minX;
        _maxX = maxX ?? _maxX;

        _minZ = minZ ?? _minZ;
        _maxZ = maxZ ?? _maxZ;
    }

    private void GetEnvPrefabs()
    {
        int preloadCount = Constants.EnvironmentGenerator.PRELOADTILECOUNT;

        _envPrefabs = new()
        {
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile1",
                new List<bool> { false, true, false, true },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile1"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile2",
                new List<bool> { true, true, true, true },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile2"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile3",
                new List<bool> { false, true, true, true },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile3"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile4",
                new List<bool> { false, true, false, true },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile4"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile5",
                new List<bool> { true, false, false, true },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile5"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile6",
                new List<bool> { false, false, false, true },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile6"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile7",
                new List<bool> { false, false, true, false },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile7"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile8",
                new List<bool> { true, false, true, false },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile8"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile9",
                new List<bool> { true, true, true, true },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile9"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile10",
                new List<bool> { false, true, true, true },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile10"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile11",
                new List<bool> { false, true, true, false },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile11"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile12",
                new List<bool> { true, false, true, false },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile12"); }, GetAction, ReturnAction, preloadCount)
                ),
            new EnvironmentPrefabForTile(
                "Prefabs/Level/New Tile/Tile13",
                new List<bool> { false, false, false, false },
                new(delegate { return Preload("Prefabs/Level/New Tile/Tile13"); }, GetAction, ReturnAction, preloadCount)
                ),
        };
    }

    private void GetPropsPrefabs()
    {
        int preloadCount = Constants.EnvironmentGenerator.PRELOADPROPSCOUNT;

        _propsLarge = new()
        {
            new("Prefabs/Props/Large/Large 1", Enums.TypeSizeProps.Large, 
                new(delegate { return Preload("Prefabs/Props/Large/Large 1"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 2", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 2"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 3", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 3"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 4", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 4"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 5", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 5"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 6", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 6"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 7", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 7"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 8", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 8"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 9", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 9"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 10", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 10"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 11", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 11"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 12", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 12"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 13", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 13"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 14", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 14"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 15", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 15"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 16", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 16"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Large/Large 17", Enums.TypeSizeProps.Large,
                new(delegate { return Preload("Prefabs/Props/Large/Large 17"); }, GetAction, ReturnAction, preloadCount)),
        };

        _propsMedium = new()
        {
            new("Prefabs/Props/Medium/Medium 1", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 1"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 2", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 2"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 3", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 3"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 4", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 4"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 5", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 5"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 6", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 6"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 7", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 7"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 8", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 8"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 9", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 9"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 10", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 10"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Medium/Medium 11", Enums.TypeSizeProps.Medium,
                new(delegate { return Preload("Prefabs/Props/Medium/Medium 11"); }, GetAction, ReturnAction, preloadCount)),
        };

        _propsSmall = new()
        {
            new("Prefabs/Props/Small/Small 1", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 1"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 2", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 2"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 3", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 3"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 4", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 4"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 5", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 5"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 6", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 6"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 7", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 7"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 8", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 8"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 9", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 9"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 10", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 10"); }, GetAction, ReturnAction, preloadCount)),
            new("Prefabs/Props/Small/Small 11", Enums.TypeSizeProps.Small,
                new(delegate { return Preload("Prefabs/Props/Small/Small 11"); }, GetAction, ReturnAction, preloadCount)),
        };
    }

    private void GeneratePossition()
    {
        var xCount = CalculateCount(_minX, _maxX, _sizeTile);
        var zCount = CalculateCount(_minZ, _maxZ, _sizeTile);

        _room = new EnvironmentPrefabForTile[zCount, xCount];

        for (int i = 0; i < zCount; i++)
        {
            for (int j = 0; j < xCount; j++)
            {
                if (i == 0 && j == 0)
                {
                    var element = rnd.Next(0, _envPrefabs.Count);
                    _room[i, j] = (EnvironmentPrefabForTile)_envPrefabs[element].Clone();
                    _room[i, j] = RotateElement(_room[i, j]);
                }
                else
                {
                    bool? top = null;
                    bool? left = null;

                    try
                    {
                        var topElement = _room[i - 1, j];
                        top = topElement.sideWall[2];
                    }
                    catch { }

                    try
                    {
                        var leftElement = _room[i, j - 1];
                        left = leftElement.sideWall[1];
                    }
                    catch { }

                    RotateAllPrefabs();

                    List<EnvironmentPrefabForTile> correctSidePrefabs = new();
                    foreach (var prefab in _envPrefabs)
                    {
                        if (top != null && left != null)
                        {
                            if (left == prefab.sideWall[3] && top == prefab.sideWall[0])
                            {
                                correctSidePrefabs.Add(prefab);
                            }
                        }
                        else if (top == null)
                        {
                            if (left == prefab.sideWall[3])
                            {
                                correctSidePrefabs.Add(prefab);
                            }
                        }
                        else
                        {
                            if (top == prefab.sideWall[0])
                            {
                                correctSidePrefabs.Add(prefab);
                            }
                        }
                    }

                    if (correctSidePrefabs.Count > 0)
                    {
                        var element = rnd.Next(0, correctSidePrefabs.Count);

                        _room[i, j] = (EnvironmentPrefabForTile)correctSidePrefabs[element].Clone();
                    }
                    else
                    {
                        var element = rnd.Next(0, _envPrefabs.Count);

                        _room[i, j] = (EnvironmentPrefabForTile)_envPrefabs[element].Clone();
                        _room[i, j] = RotateElement(_room[i, j]);
                    }
                }
            }
        }
    }

    private void SpawnEnvironment()
    {
        for(int i = 0; i < _room.GetLength(0); i++) 
        {
            for(int j = 0; j < _room.GetLength(1); j++)
            {
                var zPosition = i * _sizeTile + _minZ + _sizeTile / 2;
                var xPosition = _maxX - j * _sizeTile - _sizeTile / 2;

                GameObject gameObject = _room[i, j].pool.GetElement();
                gameObject.transform.position = new(xPosition, 0, zPosition);
                gameObject.transform.rotation = Quaternion.Euler(0, _room[i, j].rotationNumber * 90, 0);

                foreach (var prop in gameObject.GetComponentsInChildren<PropController>())
                {
                    List<PropForTile> props = prop.TypeSize == Enums.TypeSizeProps.Large ? _propsLarge :
                        prop.TypeSize == Enums.TypeSizeProps.Medium ? _propsMedium : _propsSmall;

                    prop.Spawn(props);
                }
            }
        }
    }

    private int CalculateCount(float min, float max, float size)
    {
        return (int)Math.Ceiling((max - min) / size);
    }

    private void RotateAllPrefabs()
    {
        var rotationNumber = rnd.Next(0, 4);

        for (int i = 0; i < _envPrefabs.Count; i++)
        {
            _envPrefabs[i].rotationNumber += rotationNumber % 4;

            var array = _envPrefabs[i].sideWall.ToArray();
            var shiftArray = Shift(array, rotationNumber);

            _envPrefabs[i].sideWall = shiftArray.ToList();
        }
    }

    private EnvironmentPrefabForTile RotateElement(EnvironmentPrefabForTile element) 
    {
        var rotationNumber = rnd.Next(0, 4);

        element.rotationNumber += rotationNumber % 4;

        var array = element.sideWall.ToArray();
        var shiftArray = Shift(array, rotationNumber);

        element.sideWall = shiftArray.ToList();

        return element;
    }

    private bool[] Shift(bool[] array, int k)
    {
        var result = new bool[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            if ((i + k) >= array.Length)
                result[i + k - array.Length] = array[i];
            else
                result[i + k] = array[i];
        }
        return result;
    }

    private void CleanEnvironment()
    {
        foreach(var env in _envPrefabs)
        {
            env.pool.ReturnAll();
        }

        foreach(var propLarge in _propsLarge)
        {
            propLarge.pool.ReturnAll();
        }

        foreach(var propMedium in _propsMedium)
        {
            propMedium.pool.ReturnAll();
        }

        foreach(var propSmall in _propsSmall)
        {
            propSmall.pool.ReturnAll();
        }
    }

    public GameObject Preload(string path) => Instantiate(Resources.Load(path) as GameObject, transform);
    public void GetAction(GameObject gameObject) => gameObject.SetActive(true);

    public void ReturnAction(GameObject gameObject) => gameObject.SetActive(false);
}
