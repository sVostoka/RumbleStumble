using System;
using UnityEngine;
using static Enums;

public class PropForTile : ICloneable
{
    public string prefabPath;
    public TypeSizeProps typeSize;
    public PoolBase<GameObject> pool;

    public PropForTile(string prefabPath, TypeSizeProps typeSize, PoolBase<GameObject> pool)
    {
        this.prefabPath = prefabPath;
        this.typeSize = typeSize;
        this.pool = pool;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}