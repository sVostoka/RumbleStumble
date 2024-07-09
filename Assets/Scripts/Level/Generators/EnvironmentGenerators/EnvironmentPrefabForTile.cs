using System;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPrefabForTile : ICloneable
{
    public string prefabPath;
    public List<bool> sideWall;
    public int rotationNumber;
    public PoolBase<GameObject> pool;

    public EnvironmentPrefabForTile(string prefabPath, List<bool> sideWall, PoolBase<GameObject> pool, int rotationNumber = 0)
    {
        this.prefabPath = prefabPath;
        this.sideWall = sideWall;
        this.rotationNumber = rotationNumber;
        this.pool = pool;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}
